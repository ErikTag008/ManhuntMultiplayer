using UnityEngine;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Object = UnityEngine.Object;

namespace Assets._Project._Scripts.SerializeMethod
{
    [Serializable]
    public class SerializedCallback<TReturn> : ISerializationCallbackReceiver
    {
        [SerializeField] Object _targetObject;
        [SerializeField] string _methodName;
        [SerializeField] AnyValue[] _parameters;

        [NonSerialized] Delegate _cachedDelegate;
        [NonSerialized] bool _isDelegateRebuilt;

        public TReturn Invoke()
        {
            return Invoke(_parameters);
        }

        public TReturn Invoke(params AnyValue[] args)
        {
            if (!_isDelegateRebuilt) BuildDelegate();

            if (_cachedDelegate != null)
            {
                var result = _cachedDelegate.DynamicInvoke(ConvertParameters(args));
                return (TReturn)Convert.ChangeType(result, typeof(TReturn));
            }
            Debug.LogWarning($"Unable to invoke method {_methodName} on {_targetObject}");
            return default;
        }

        object[] ConvertParameters(AnyValue[] args)
        {
            if (args == null || args.Length == 0) return Array.Empty<object>();

            var convertedParams = new object[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                convertedParams[i] = args[i].ConvertValue<object>();
            }
            return convertedParams;
        }

        void BuildDelegate()
        {
            _cachedDelegate = null;

            if (_targetObject == null || string.IsNullOrEmpty(_methodName))
            {
                Debug.LogWarning("Target object or method name is null, cannot rebuild delegate.");
                return;
            }

            Type targetType = _targetObject.GetType();
            MethodInfo methodInfo = targetType.GetMethod(_methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (methodInfo == null)
            {
                Debug.LogWarning($"Method {_methodName} not found on {_targetObject}");
                return;
            }

            Type[] parameterTypes = methodInfo.GetParameters().Select(p => p.ParameterType).ToArray();
            if (_parameters.Length != parameterTypes.Length)
            {
                Debug.LogWarning($"Parameter mismatch for method {_methodName}");
                return;
            }

            Type delegateType = Expression.GetDelegateType(parameterTypes.Append(methodInfo.ReturnType).ToArray());
            _cachedDelegate = methodInfo.CreateDelegate(delegateType, _targetObject);
            _isDelegateRebuilt = true;
        }

        public void OnBeforeSerialize()
        {
            // noop
        }

        public void OnAfterDeserialize()
        {
            _isDelegateRebuilt = false;
        }
    }


    [Serializable]
    public class SerializedCallback : ISerializationCallbackReceiver
    {
        [SerializeField] Object _targetObject;
        [SerializeField] string _methodName;
        [SerializeField] AnyValue[] _parameters;

        [NonSerialized] Delegate _cachedDelegate;
        [NonSerialized] bool _isDelegateRebuilt;

        public void Invoke()
        {
            Invoke(_parameters);
        }

        public void Invoke(params AnyValue[] args)
        {
            if (!_isDelegateRebuilt) BuildDelegate();

            _cachedDelegate?.DynamicInvoke(ConvertParameters(args));
            Debug.LogWarning($"Unable to invoke method {_methodName} on {_targetObject}");
        }

        object[] ConvertParameters(AnyValue[] args)
        {
            if (args == null || args.Length == 0) return Array.Empty<object>();

            var convertedParams = new object[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                convertedParams[i] = args[i].ConvertValue<object>();
            }
            return convertedParams;
        }

        void BuildDelegate()
        {
            _cachedDelegate = null;

            if (_targetObject == null || string.IsNullOrEmpty(_methodName))
            {
                Debug.LogWarning("Target object or method name is null, cannot rebuild delegate.");
                return;
            }

            Type targetType = _targetObject.GetType();
            MethodInfo methodInfo = targetType.GetMethod(_methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (methodInfo == null)
            {
                Debug.LogWarning($"Method {_methodName} not found on {_targetObject}");
                return;
            }

            Type[] parameterTypes = methodInfo.GetParameters().Select(p => p.ParameterType).ToArray();
            if (_parameters.Length != parameterTypes.Length)
            {
                Debug.LogWarning($"Parameter mismatch for method {_methodName}");
                return;
            }

            Type delegateType = Expression.GetDelegateType(parameterTypes.Append(methodInfo.ReturnType).ToArray());
            _cachedDelegate = methodInfo.CreateDelegate(delegateType, _targetObject);
            _isDelegateRebuilt = true;
        }

        public void OnBeforeSerialize()
        {
            // noop
        }

        public void OnAfterDeserialize()
        {
            _isDelegateRebuilt = false;
        }
    }
}
