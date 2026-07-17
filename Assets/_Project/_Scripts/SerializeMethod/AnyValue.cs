namespace Assets._Project._Scripts.SerializeMethod
{
    using System;
    using UnityEngine;

    public enum ValueType { Int, Float, Bool, String, Vector3 }

    [Serializable]
    public struct AnyValue
    {
        public ValueType Type;

        // Storage for different types of values
        public bool BoolValue;
        public int IntValue;
        public float FloatValue;
        public string StringValue;
        public Vector3 Vector3Value;

        // Implicit conversion operators to convert AnyValue to different types
        public static implicit operator bool(AnyValue value) => value.ConvertValue<bool>();
        public static implicit operator int(AnyValue value) => value.ConvertValue<int>();
        public static implicit operator float(AnyValue value) => value.ConvertValue<float>();
        public static implicit operator string(AnyValue value) => value.ConvertValue<string>();
        public static implicit operator Vector3(AnyValue value) => value.ConvertValue<Vector3>();

        public readonly T ConvertValue<T>()
        {
            if (typeof(T) == typeof(object)) return CastToObject<T>();
            return Type switch
            {
                ValueType.Int => AsInt<T>(IntValue),
                ValueType.Float => AsFloat<T>(FloatValue),
                ValueType.Bool => AsBool<T>(BoolValue),
                ValueType.String => (T)(object)StringValue,
                ValueType.Vector3 => AsVector3<T>(Vector3Value),
                _ => throw new InvalidCastException($"Cannot convert AnyValue of type {Type} to {typeof(T).Name}")
            };
        }

        // Helper methods for safe type conversions of the value types without the cost of boxing
        readonly T AsBool<T>(bool value) => typeof(T) == typeof(bool) && value is T correctType ? correctType : default;
        readonly T AsInt<T>(int value) => typeof(T) == typeof(int) && value is T correctType ? correctType : default;
        readonly T AsFloat<T>(float value) => typeof(T) == typeof(float) && value is T correctType ? correctType : default;
        readonly T AsVector3<T>(Vector3 value) => typeof(T) == typeof(Vector3) && value is T correctType ? correctType : default;

        public static Type TypeOf(ValueType valueType)
        {
            return valueType switch
            {
                ValueType.Bool => typeof(bool),
                ValueType.Int => typeof(int),
                ValueType.Float => typeof(float),
                ValueType.String => typeof(string),
                ValueType.Vector3 => typeof(Vector3),
                _ => throw new NotSupportedException($"Unsupported ValueType: {valueType}")
            };
        }

        public static ValueType ValueTypeOf(Type type)
        {
            return type switch
            {
                _ when type == typeof(bool) => ValueType.Bool,
                _ when type == typeof(int) => ValueType.Int,
                _ when type == typeof(float) => ValueType.Float,
                _ when type == typeof(string) => ValueType.String,
                _ when type == typeof(Vector3) => ValueType.Vector3,
                _ => throw new NotSupportedException($"Unsupported type: {type}")
            };
        }

        readonly T CastToObject<T>()
        {
            return Type switch
            {
                ValueType.Int => (T)(object)IntValue,
                ValueType.Float => (T)(object)FloatValue,
                ValueType.Bool => (T)(object)BoolValue,
                ValueType.String => (T)(object)StringValue,
                ValueType.Vector3 => (T)(object)Vector3Value,
                _ => throw new InvalidCastException($"Cannot convert AnyValue of type {Type} to {typeof(T).Name}")
            };
        }
    }
}
