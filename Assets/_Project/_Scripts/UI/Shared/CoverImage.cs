using KBCore.Refs;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Assets._Project._Scripts.UI.Shared
{
    // Shows a texture filling its RawImage without stretching: the parts that don't fit the rect's aspect are cropped evenly
    [RequireComponent(typeof(RawImage))]
    public class CoverImage : ValidatedMonoBehaviour
    {
        private const float Half = 0.5f;
        private static readonly Rect FullRect = new(0f, 0f, 1f, 1f);

        [SerializeField, Self] private RawImage _image;

        public void ChangeTexture(Texture texture)
        {
            _image.texture = texture;
            FitToRect();
        }

        // the layout sizes the rect after the texture is set
        private void OnRectTransformDimensionsChange() => FitToRect();

        private void FitToRect()
        {
            if (_image == null) return;

            var texture = _image.texture;
            Rect rect = _image.rectTransform.rect;
            if (texture == null || texture.height <= 0 || rect.width <= 0f || rect.height <= 0f)
            {
                _image.uvRect = FullRect;
                return;
            }

            float rectAspect = rect.width / rect.height;
            float textureAspect = (float)texture.width / texture.height;
            if (textureAspect > rectAspect)
            {
                float width = rectAspect / textureAspect;
                _image.uvRect = new Rect((1f - width) * Half, 0f, width, 1f);
            }
            else
            {
                float height = textureAspect / rectAspect;
                _image.uvRect = new Rect(0f, (1f - height) * Half, 1f, height);
            }
        }
    }
}
