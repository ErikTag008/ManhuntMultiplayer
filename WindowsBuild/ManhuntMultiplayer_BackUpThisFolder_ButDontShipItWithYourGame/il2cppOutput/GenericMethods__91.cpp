#include "pch-cpp.hpp"





template <typename R>
struct VirtualFuncInvoker0
{
	typedef R (*Func)(void*,const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj,invokeData.method);
	}
};
template <typename R, typename T1>
struct VirtualFuncInvoker1
{
	typedef R (*Func)(void*,T1,const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		return ((Func)invokeData.methodPtr)(obj,p1,invokeData.method);
	}
};
template <typename T1, typename T2>
struct InvokerActionInvoker2;
template <typename T1, typename T2>
struct InvokerActionInvoker2<T1*, T2*>
{
	static inline void Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2* p2)
	{
		void* params[2] = { p1, p2 };
		method->invoker_method(methodPtr, method, obj, params, params[1]);
	}
};
template <typename R, typename T1, typename T2>
struct InvokerFuncInvoker2;
template <typename R, typename T1, typename T2>
struct InvokerFuncInvoker2<R, T1*, T2*>
{
	static inline R Invoke (Il2CppMethodPointer methodPtr, const RuntimeMethod* method, void* obj, T1* p1, T2* p2)
	{
		R ret;
		void* params[2] = { p1, p2 };
		method->invoker_method(methodPtr, method, obj, params, &ret);
		return ret;
	}
};

struct Dictionary_2_t7E2B528AFC59C90DE8916832B84A9936D8967195;
struct Dictionary_2_tD77528C78AECDC8F6DF50F36B79092A52A270629;
struct Dictionary_2_t29FB78C9E5DF443E2A5880E4E9B7C86E516670E0;
struct List_1_tE7FB077B3CEA6371A27F72CC60962491AB71490B;
struct List_1_tBD2E4781BB0BD1FCD30E6D3586CA13AFD0ABE6F7;
struct List_1_t491347B1404617671B39DA9325642B0DB8748CB3;
struct List_1_tD6F1685FEE5A196B3002ACC649A1DF5C65162268;
struct List_1_t437B6C3879E969156A381BDC3C459CF809D39DDF;
struct TypeConverter_2_tF89582388D90E6733D9336D56E72113181F8C35B;
struct TypeConverter_2_t6639570A10ABBF2F824E8BC88925BA36914DC1C7;
struct TypeConverter_2_t14B52AF1258A5A9C9C7C40B585BCC796EB89546E;
struct TypeConverter_2_t0D424B5552ED05121DAA8FBC96BFA5B5D7C25841;
struct TypeConverter_2_t325870E3CF7DE93A02F5E359A73B09EE687F7764;
struct TypeConverter_2_t77EBC7DE8779DBFC8C888CCCBA1C57A1900F8D0E;
struct TypeConverter_2_t2590D829276A4C224936EDAFCF1D1137DC63F062;
struct TypeConverter_2_t3B4B4ED61AFE2B4C7E58725FA7AE976658EDFC5F;
struct TypeConverter_2_tE6C2466AFC58085EAE6299B76802C78CC1C80F0D;
struct TypeConverter_2_tE2027A3B32E1BB438286300A403B88A772D4E99F;
struct TypeConverter_2_t73501A4CF3B35838D78DF2D56FF13675BEADC04B;
struct TypeConverter_2_tC0A832D8646E8260644D66DD7FA213AC57484831;
struct TypeConverter_2_t0A5CBF00DFB82526AEB7B2DFEF71CA4F4807581E;
struct TypeConverter_2_tBA10E08FB2B7207E85EAB1039CE76A8D80224B20;
struct TypeConverter_2_t26D60543337DCCA819FD538D85F40D86762DB0F2;
struct TypeConverter_2_tC8DC9C48FBE571CF2E75D0324F34468EACBEB008;
struct TypeConverter_2_t7104BAD86AB01041A6B4CFA05DD8A0CF7B316EAE;
struct TypeConverter_2_t987BA7DD2FE661C6A4CD1CE7F398720A1A912CDB;
struct TypeConverter_2_tFE7942B61544B13EC61F654A379BB8C5C19E478F;
struct TypeConverter_2_t4C7D6F1114B9EFC390F0FE6F2860EDC1E7DF3049;
struct TypeConverter_2_tA9C93925BAFC7D4786356A2B45762EB2575F3986;
struct TypeConverter_2_t2257368AB189DB95AF22DD35774E8FEB55C630BB;
struct TypeConverter_2_t0525BA89BAB435F8C9F2EEF9023F9BCB7ABE80A1;
struct TypeConverter_2_t81D4A80534427AD7BC452191F15131144F2FF763;
struct TypeConverter_2_tA6276E0BDB8DB9E3B10AF0C31301ACC071589845;
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;
struct CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB;
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
struct Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C;
struct IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832;
struct StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF;
struct TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB;
struct Binder_t91BFCE95A7057FADF4D8A1A342AFE52872246235;
struct Delegate_t;
struct DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E;
struct FilterFunctionDefinition_tFE41DB19FFB74F4D2B54BF44D1D2051B57FC82F2;
struct Font_tC95270EA3198038970422D78B74A7F2E218A96B6;
struct FontAsset_t61A6446D934E582651044E33D250EA8D306AB958;
struct IDictionary_t6D03155AF1FA9083817AA5B6AD7DEEACC26AB220;
struct Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3;
struct MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553;
struct MethodInfo_t;
struct RenderTexture_tBA90C4C3AD9EECCFDDCC632D97C29FAB80D60D27;
struct SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6;
struct Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99;
struct String_t;
struct Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4;
struct Type_t;
struct UIAnimationClip_tFB53C6186F959E95BDF9FC388D9F67925289363A;
struct UnsafePackedBinaryStream_tA167AA778E63332B246152289D19AED3846C8DFE;
struct VectorImage_t7BD8CE948377FFE95FCA0C48014ACDFC13B8F8FC;
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;

IL2CPP_EXTERN_C RuntimeClass* ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* RuntimeObject_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* String_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Type_t_il2cpp_TypeInfo_var;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;


IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
struct MemberInfo_t  : public RuntimeObject
{
};
struct String_t  : public RuntimeObject
{
	int32_t ____stringLength;
	Il2CppChar ____firstChar;
};
struct TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};
struct KeyValuePair_2_tEB5CFC17B6D8F2A082613AF75FCB091A2A4EB826 
{
	Il2CppSharedGenericObject* ___key;
	Il2CppSharedGenericObject* ___value;
};
struct Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8 
{
	Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* ___m_Texture;
	Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99* ___m_Sprite;
	RenderTexture_tBA90C4C3AD9EECCFDDCC632D97C29FAB80D60D27* ___m_RenderTexture;
	VectorImage_t7BD8CE948377FFE95FCA0C48014ACDFC13B8F8FC* ___m_VectorImage;
};
struct Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8_marshaled_pinvoke
{
	Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* ___m_Texture;
	Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99* ___m_Sprite;
	RenderTexture_tBA90C4C3AD9EECCFDDCC632D97C29FAB80D60D27* ___m_RenderTexture;
	VectorImage_t7BD8CE948377FFE95FCA0C48014ACDFC13B8F8FC* ___m_VectorImage;
};
struct Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8_marshaled_com
{
	Texture2D_tE6505BC111DD8A424A9DBE8E05D7D09E11FFFCF4* ___m_Texture;
	Sprite_tAFF74BC83CD68037494CB0B4F28CBDF8971CAB99* ___m_Sprite;
	RenderTexture_tBA90C4C3AD9EECCFDDCC632D97C29FAB80D60D27* ___m_RenderTexture;
	VectorImage_t7BD8CE948377FFE95FCA0C48014ACDFC13B8F8FC* ___m_VectorImage;
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	bool ___m_value;
};
struct Byte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3 
{
	uint8_t ___m_value;
};
struct Char_t521A6F19B456D956AF452D926C32709DC03D6B17 
{
	Il2CppChar ___m_value;
};
struct Color_tD001788D726C3A7F1379BEED0260B9591F440C1F 
{
	float ___r;
	float ___g;
	float ___b;
	float ___a;
};
struct ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426 
{
	Dictionary_2_tD77528C78AECDC8F6DF50F36B79092A52A270629* ___m_Converters;
	Dictionary_2_t7E2B528AFC59C90DE8916832B84A9936D8967195* ___m_LazyConverters;
};
struct ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426_marshaled_pinvoke
{
	Dictionary_2_tD77528C78AECDC8F6DF50F36B79092A52A270629* ___m_Converters;
	Dictionary_2_t7E2B528AFC59C90DE8916832B84A9936D8967195* ___m_LazyConverters;
};
struct ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426_marshaled_com
{
	Dictionary_2_tD77528C78AECDC8F6DF50F36B79092A52A270629* ___m_Converters;
	Dictionary_2_t7E2B528AFC59C90DE8916832B84A9936D8967195* ___m_LazyConverters;
};
struct DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D 
{
	uint64_t ____dateData;
};
struct Double_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F 
{
	double ___m_value;
};
struct EntityId_t982FBD037EAC5CA077B1602A7EA40E3523AA0FC8 
{
	union
	{
		struct
		{
			uint64_t ___m_rawData;
		};
		uint8_t EntityId_t982FBD037EAC5CA077B1602A7EA40E3523AA0FC8__padding[8];
	};
};
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2  : public ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F
{
};
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_marshaled_pinvoke
{
};
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_marshaled_com
{
};
struct FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C 
{
	Font_tC95270EA3198038970422D78B74A7F2E218A96B6* ___m_Font;
	FontAsset_t61A6446D934E582651044E33D250EA8D306AB958* ___m_FontAsset;
};
struct FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C_marshaled_pinvoke
{
	Font_tC95270EA3198038970422D78B74A7F2E218A96B6* ___m_Font;
	FontAsset_t61A6446D934E582651044E33D250EA8D306AB958* ___m_FontAsset;
};
struct FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C_marshaled_com
{
	Font_tC95270EA3198038970422D78B74A7F2E218A96B6* ___m_Font;
	FontAsset_t61A6446D934E582651044E33D250EA8D306AB958* ___m_FontAsset;
};
struct GradientAlphaKey_tF469955E4BBAF1044320D956CD8D990F1A26EAA0 
{
	float ___alpha;
	float ___time;
};
struct Guid_t 
{
	int32_t ____a;
	int16_t ____b;
	int16_t ____c;
	uint8_t ____d;
	uint8_t ____e;
	uint8_t ____f;
	uint8_t ____g;
	uint8_t ____h;
	uint8_t ____i;
	uint8_t ____j;
	uint8_t ____k;
};
struct Handle_t734A63706EDE11FF0429B53F7756AE2873E1F665 
{
	int32_t ___Index;
	int32_t ___Version;
};
struct Int16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175 
{
	int16_t ___m_value;
};
struct Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C 
{
	int32_t ___m_value;
};
struct Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3 
{
	int64_t ___m_value;
};
struct IntPtr_t 
{
	void* ___m_value;
};
struct Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0 
{
	float ___m_Time;
	float ___m_Value;
	float ___m_InTangent;
	float ___m_OutTangent;
	int32_t ___m_WeightedMode;
	float ___m_InWeight;
	float ___m_OutWeight;
};
struct MaterialDefinition_t25B84AF58B1F4D1990933E5EBCD2DE6989ECB8CD 
{
	Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* ___m_Material;
	List_1_t491347B1404617671B39DA9325642B0DB8748CB3* ___propertyValues;
};
struct MaterialDefinition_t25B84AF58B1F4D1990933E5EBCD2DE6989ECB8CD_marshaled_pinvoke
{
	Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* ___m_Material;
	List_1_t491347B1404617671B39DA9325642B0DB8748CB3* ___propertyValues;
};
struct MaterialDefinition_t25B84AF58B1F4D1990933E5EBCD2DE6989ECB8CD_marshaled_com
{
	Material_t18053F08F347D0DCA5E1140EC7EC4533DD8A14E3* ___m_Material;
	List_1_t491347B1404617671B39DA9325642B0DB8748CB3* ___propertyValues;
};
struct Ratio_t66C366BD5A2636748B25C00FD6A63F40A09712B3 
{
	float ___m_Value;
};
struct SByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5 
{
	int8_t ___m_value;
};
struct Single_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C 
{
	float ___m_value;
};
struct TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A 
{
	int64_t ____ticks;
};
struct UInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455 
{
	uint16_t ___m_value;
};
struct UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B 
{
	uint32_t ___m_value;
};
struct UInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF 
{
	uint64_t ___m_value;
};
struct Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 
{
	float ___x;
	float ___y;
};
struct Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 
{
	float ___x;
	float ___y;
	float ___z;
};
struct Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 
{
	int32_t ___m_X;
	int32_t ___m_Y;
	int32_t ___m_Z;
};
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};
struct BackgroundPositionKeyword_tE680A05B983D256AADC8E2CF1CA169D004B8641B 
{
	int32_t ___value__;
};
struct BackgroundSizeType_tD194B20FF5086D494ABF8D799124D2FC4FFCC674 
{
	int32_t ___value__;
};
struct Cursor_t24C3B5095F65B86794C4F7EA168E324DFDA9EE82 
{
	union
	{
		struct
		{
			EntityId_t982FBD037EAC5CA077B1602A7EA40E3523AA0FC8 ___m_Texture;
			int32_t ___m_DefaultCursorId;
			int32_t _____dummy;
			Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___m_Hotspot;
		};
		uint8_t Cursor_t24C3B5095F65B86794C4F7EA168E324DFDA9EE82__padding[24];
	};
};
struct Delegate_t  : public RuntimeObject
{
	intptr_t ___method_ptr;
	intptr_t ___invoke_impl;
	RuntimeObject* ___m_target;
	intptr_t ___method;
	intptr_t ___delegate_trampoline;
	intptr_t ___extra_arg;
	intptr_t ___method_code;
	intptr_t ___interp_method;
	intptr_t ___interp_invoke_impl;
	MethodInfo_t* ___method_info;
	MethodInfo_t* ___original_method_info;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data;
	bool ___method_is_virtual;
};
struct Delegate_t_marshaled_pinvoke
{
	intptr_t ___method_ptr;
	intptr_t ___invoke_impl;
	Il2CppIUnknown* ___m_target;
	intptr_t ___method;
	intptr_t ___delegate_trampoline;
	intptr_t ___extra_arg;
	intptr_t ___method_code;
	intptr_t ___interp_method;
	intptr_t ___interp_invoke_impl;
	MethodInfo_t* ___method_info;
	MethodInfo_t* ___original_method_info;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data;
	int32_t ___method_is_virtual;
};
struct Delegate_t_marshaled_com
{
	intptr_t ___method_ptr;
	intptr_t ___invoke_impl;
	Il2CppIUnknown* ___m_target;
	intptr_t ___method;
	intptr_t ___delegate_trampoline;
	intptr_t ___extra_arg;
	intptr_t ___method_code;
	intptr_t ___interp_method;
	intptr_t ___interp_invoke_impl;
	MethodInfo_t* ___method_info;
	MethodInfo_t* ___original_method_info;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data;
	int32_t ___method_is_virtual;
};
struct EasingMode_tEF87477B9B9EB2524525550AE5ABEBC00FC7B0DF 
{
	int32_t ___value__;
};
struct Exception_t  : public RuntimeObject
{
	String_t* ____className;
	String_t* ____message;
	RuntimeObject* ____data;
	Exception_t* ____innerException;
	String_t* ____helpURL;
	RuntimeObject* ____stackTrace;
	String_t* ____stackTraceString;
	String_t* ____remoteStackTraceString;
	int32_t ____remoteStackIndex;
	RuntimeObject* ____dynamicMethods;
	int32_t ____HResult;
	String_t* ____source;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces;
	IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832* ___native_trace_ips;
	int32_t ___caught_in_unmanaged;
};
struct Exception_t_marshaled_pinvoke
{
	char* ____className;
	char* ____message;
	RuntimeObject* ____data;
	Exception_t_marshaled_pinvoke* ____innerException;
	char* ____helpURL;
	Il2CppIUnknown* ____stackTrace;
	char* ____stackTraceString;
	char* ____remoteStackTraceString;
	int32_t ____remoteStackIndex;
	Il2CppIUnknown* ____dynamicMethods;
	int32_t ____HResult;
	char* ____source;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces;
	Il2CppSafeArray* ___native_trace_ips;
	int32_t ___caught_in_unmanaged;
};
struct Exception_t_marshaled_com
{
	Il2CppChar* ____className;
	Il2CppChar* ____message;
	RuntimeObject* ____data;
	Exception_t_marshaled_com* ____innerException;
	Il2CppChar* ____helpURL;
	Il2CppIUnknown* ____stackTrace;
	Il2CppChar* ____stackTraceString;
	Il2CppChar* ____remoteStackTraceString;
	int32_t ____remoteStackIndex;
	Il2CppIUnknown* ____dynamicMethods;
	int32_t ____HResult;
	Il2CppChar* ____source;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces;
	Il2CppSafeArray* ___native_trace_ips;
	int32_t ___caught_in_unmanaged;
};
struct FilterFunctionType_tF29290365A61009BE6F2EF6C6C6218E72CB9F64A 
{
	int32_t ___value__;
};
struct FilterParameterType_t7250262A78079140235AAFF6F4FA3CCB2F99E390 
{
	int32_t ___value__;
};
struct GradientColorKey_tBD03A613338639E3774A10265CC5F3619C13421A 
{
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___color;
	float ___time;
};
struct LayoutUnit_tF18EC17FE8588A01C72784546410EA0D9B1D2F22 
{
	int32_t ___value__;
};
struct Repeat_tC0330B75B12D24B063BA5151AF3BB73B85D8B840 
{
	int32_t ___value__;
};
struct RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B 
{
	intptr_t ___value;
};
struct Scale_t5594C69C1AC9398B57ABF6C4FA0D4E791B7A4DC7 
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_Scale;
	bool ___m_IsNone;
};
struct Scale_t5594C69C1AC9398B57ABF6C4FA0D4E791B7A4DC7_marshaled_pinvoke
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_Scale;
	int32_t ___m_IsNone;
};
struct Scale_t5594C69C1AC9398B57ABF6C4FA0D4E791B7A4DC7_marshaled_com
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_Scale;
	int32_t ___m_IsNone;
};
struct SerializedArrayView_t811E52198172559E69CE9093CCE7C7970D3A46D6 
{
	UnsafePackedBinaryStream_tA167AA778E63332B246152289D19AED3846C8DFE* ___m_Stream;
	Handle_t734A63706EDE11FF0429B53F7756AE2873E1F665 ___m_Handle;
};
struct SerializedObjectView_t3371CA1D296BF0161DBD7A002673B96D76927561 
{
	UnsafePackedBinaryStream_tA167AA778E63332B246152289D19AED3846C8DFE* ___m_Stream;
	Handle_t734A63706EDE11FF0429B53F7756AE2873E1F665 ___m_Handle;
};
struct SerializedValueView_t132982877F69EB6A5B24A9B8EB004A6B80D087DC 
{
	UnsafePackedBinaryStream_tA167AA778E63332B246152289D19AED3846C8DFE* ___m_Stream;
	Handle_t734A63706EDE11FF0429B53F7756AE2873E1F665 ___m_Handle;
};
struct StyleKeyword_t2812E72266C15CBA8927586972DC2FD27B10E705 
{
	int32_t ___value__;
};
struct StylePropertyId_tA3B8A5213F5BA43F9C5443B27B165D744713BE69 
{
	int32_t ___value__;
};
struct TextAutoSizeMode_t10C0C54209C97D8A231AF021AE2F9DFFD26EE2C9 
{
	int32_t ___value__;
};
struct TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05 
{
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___color;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___offset;
	float ___blurRadius;
};
struct TimeUnit_t56A79CDB672E98A4EE28002BD23B6D5E0BAA2649 
{
	int32_t ___value__;
};
struct Unit_t21DCD5C095F7DC1A0B9A47CAF8CAD3E7776CD3DB 
{
	int32_t ___value__;
};
struct StyleEnum_1_tAFD4AA79F79D19DE23805D46DA67778A70EBBF26 
{
	int32_t ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleList_1_t5D2FA4535A553635ADCE6E1E3758E1FA02160E6F 
{
	int32_t ___m_Keyword;
	List_1_tE7FB077B3CEA6371A27F72CC60962491AB71490B* ___m_Value;
};
struct StyleList_1_t8C83D4A5BF11A124E8127624CA6DC7ED436CA356 
{
	int32_t ___m_Keyword;
	List_1_tBD2E4781BB0BD1FCD30E6D3586CA13AFD0ABE6F7* ___m_Value;
};
struct StyleList_1_tABF3DD9EB70CDF59829924CBA26ACDD1FBDD4C3C 
{
	int32_t ___m_Keyword;
	List_1_tD6F1685FEE5A196B3002ACC649A1DF5C65162268* ___m_Value;
};
struct StyleList_1_t15E0FB58274532956EB643D58F1F7B95BED5B7C4 
{
	int32_t ___m_Keyword;
	List_1_t437B6C3879E969156A381BDC3C459CF809D39DDF* ___m_Value;
};
struct Angle_t0229F612898D65B3CC646C40A32D93D8A33C1DFC 
{
	float ___m_Value;
	int32_t ___m_Unit;
};
struct BackgroundRepeat_t446EC7315DED2C6822F1047B7587C3018BFB277F 
{
	int32_t ___x;
	int32_t ___y;
};
struct EasingFunction_t5197D3B06056326A8B5C96032CDEBD5D3BDCA7A4 
{
	int32_t ___m_Mode;
};
struct FilterParameter_tC6BAE67835BA35634A769B28BF35314AF42BE060 
{
	int32_t ___m_Type;
	float ___m_FloatValue;
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___m_ColorValue;
};
struct Length_t90BB06D47DD6DB461ED21BD3E3241FAB6C824256 
{
	float ___m_Value;
	int32_t ___m_Unit;
};
struct MulticastDelegate_t  : public Delegate_t
{
	DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771* ___delegates;
};
struct MulticastDelegate_t_marshaled_pinvoke : public Delegate_t_marshaled_pinvoke
{
	Delegate_t_marshaled_pinvoke** ___delegates;
};
struct MulticastDelegate_t_marshaled_com : public Delegate_t_marshaled_com
{
	Delegate_t_marshaled_com** ___delegates;
};
struct StyleBackground_t28A4439F46056BAFA6F4450CD1DE8F333571C97B 
{
	Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8 ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleBackground_t28A4439F46056BAFA6F4450CD1DE8F333571C97B_marshaled_pinvoke
{
	Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8_marshaled_pinvoke ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleBackground_t28A4439F46056BAFA6F4450CD1DE8F333571C97B_marshaled_com
{
	Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8_marshaled_com ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleColor_tFC32BA34A15742AC48D6AACF8A137A6F71F04910 
{
	Color_tD001788D726C3A7F1379BEED0260B9591F440C1F ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleCursor_tE485E9D7E54AC3A3D514CD63313D77F75BD8C610 
{
	Cursor_t24C3B5095F65B86794C4F7EA168E324DFDA9EE82 ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleFloat_t4A100BCCDC275C2302517C5858C9BE9EC43D4841 
{
	float ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleFont_t9D8A6F3E224B60FD8BA1522CE8AB0E2E8BE8B77C 
{
	Font_tC95270EA3198038970422D78B74A7F2E218A96B6* ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleFont_t9D8A6F3E224B60FD8BA1522CE8AB0E2E8BE8B77C_marshaled_pinvoke
{
	Font_tC95270EA3198038970422D78B74A7F2E218A96B6* ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleFont_t9D8A6F3E224B60FD8BA1522CE8AB0E2E8BE8B77C_marshaled_com
{
	Font_tC95270EA3198038970422D78B74A7F2E218A96B6* ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleFontDefinition_t0E1130277B322724A677D489018D219F014070F4 
{
	int32_t ___m_Keyword;
	FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C ___m_Value;
};
struct StyleFontDefinition_t0E1130277B322724A677D489018D219F014070F4_marshaled_pinvoke
{
	int32_t ___m_Keyword;
	FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C_marshaled_pinvoke ___m_Value;
};
struct StyleFontDefinition_t0E1130277B322724A677D489018D219F014070F4_marshaled_com
{
	int32_t ___m_Keyword;
	FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C_marshaled_com ___m_Value;
};
struct StyleInt_tDC5B2FE9B1ABA54EEF85A7798F321F40BDC8B25D 
{
	int32_t ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471 
{
	MaterialDefinition_t25B84AF58B1F4D1990933E5EBCD2DE6989ECB8CD ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471_marshaled_pinvoke
{
	MaterialDefinition_t25B84AF58B1F4D1990933E5EBCD2DE6989ECB8CD_marshaled_pinvoke ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471_marshaled_com
{
	MaterialDefinition_t25B84AF58B1F4D1990933E5EBCD2DE6989ECB8CD_marshaled_com ___m_Value;
	int32_t ___m_Keyword;
};
struct StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF 
{
	int32_t ___U3CidU3Ek__BackingField;
	String_t* ___U3CnameU3Ek__BackingField;
};
struct StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF_marshaled_pinvoke
{
	int32_t ___U3CidU3Ek__BackingField;
	char* ___U3CnameU3Ek__BackingField;
};
struct StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF_marshaled_com
{
	int32_t ___U3CidU3Ek__BackingField;
	Il2CppChar* ___U3CnameU3Ek__BackingField;
};
struct StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906 
{
	Ratio_t66C366BD5A2636748B25C00FD6A63F40A09712B3 ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC 
{
	Scale_t5594C69C1AC9398B57ABF6C4FA0D4E791B7A4DC7 ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC_marshaled_pinvoke
{
	Scale_t5594C69C1AC9398B57ABF6C4FA0D4E791B7A4DC7_marshaled_pinvoke ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC_marshaled_com
{
	Scale_t5594C69C1AC9398B57ABF6C4FA0D4E791B7A4DC7_marshaled_com ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252 
{
	int32_t ___m_Keyword;
	TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05 ___m_Value;
};
struct StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5 
{
	UIAnimationClip_tFB53C6186F959E95BDF9FC388D9F67925289363A* ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5_marshaled_pinvoke
{
	UIAnimationClip_tFB53C6186F959E95BDF9FC388D9F67925289363A* ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5_marshaled_com
{
	UIAnimationClip_tFB53C6186F959E95BDF9FC388D9F67925289363A* ___m_Value;
	int32_t ___m_Keyword;
};
struct SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295  : public Exception_t
{
};
struct TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E 
{
	float ___m_Value;
	int32_t ___m_Unit;
};
struct Type_t  : public MemberInfo_t
{
	RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B ____impl;
};
struct FixedBuffer4_1_tFD261E0E1A5ECEFC54C0B0B89FA6BFEE477E4D8C 
{
	FilterParameter_tC6BAE67835BA35634A769B28BF35314AF42BE060 _____0;
	FilterParameter_tC6BAE67835BA35634A769B28BF35314AF42BE060 _____1;
	FilterParameter_tC6BAE67835BA35634A769B28BF35314AF42BE060 _____2;
	FilterParameter_tC6BAE67835BA35634A769B28BF35314AF42BE060 _____3;
};
struct TypeConverter_2_tF89582388D90E6733D9336D56E72113181F8C35B  : public MulticastDelegate_t
{
};
struct TypeConverter_2_t6639570A10ABBF2F824E8BC88925BA36914DC1C7  : public MulticastDelegate_t
{
};
struct TypeConverter_2_t14B52AF1258A5A9C9C7C40B585BCC796EB89546E  : public MulticastDelegate_t
{
};
struct TypeConverter_2_t325870E3CF7DE93A02F5E359A73B09EE687F7764  : public MulticastDelegate_t
{
};
struct TypeConverter_2_t2590D829276A4C224936EDAFCF1D1137DC63F062  : public MulticastDelegate_t
{
};
struct TypeConverter_2_tE2027A3B32E1BB438286300A403B88A772D4E99F  : public MulticastDelegate_t
{
};
struct TypeConverter_2_tC0A832D8646E8260644D66DD7FA213AC57484831  : public MulticastDelegate_t
{
};
struct TypeConverter_2_t0A5CBF00DFB82526AEB7B2DFEF71CA4F4807581E  : public MulticastDelegate_t
{
};
struct TypeConverter_2_tBA10E08FB2B7207E85EAB1039CE76A8D80224B20  : public MulticastDelegate_t
{
};
struct TypeConverter_2_t7104BAD86AB01041A6B4CFA05DD8A0CF7B316EAE  : public MulticastDelegate_t
{
};
struct TypeConverter_2_t987BA7DD2FE661C6A4CD1CE7F398720A1A912CDB  : public MulticastDelegate_t
{
};
struct TypeConverter_2_tFE7942B61544B13EC61F654A379BB8C5C19E478F  : public MulticastDelegate_t
{
};
struct TypeConverter_2_t4C7D6F1114B9EFC390F0FE6F2860EDC1E7DF3049  : public MulticastDelegate_t
{
};
struct TypeConverter_2_tA9C93925BAFC7D4786356A2B45762EB2575F3986  : public MulticastDelegate_t
{
};
struct TypeConverter_2_t2257368AB189DB95AF22DD35774E8FEB55C630BB  : public MulticastDelegate_t
{
};
struct TypeConverter_2_t0525BA89BAB435F8C9F2EEF9023F9BCB7ABE80A1  : public MulticastDelegate_t
{
};
struct TypeConverter_2_t81D4A80534427AD7BC452191F15131144F2FF763  : public MulticastDelegate_t
{
};
struct TypeConverter_2_tA6276E0BDB8DB9E3B10AF0C31301ACC071589845  : public MulticastDelegate_t
{
};
struct ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
	String_t* ____paramName;
};
struct BackgroundPosition_tF0822B29FC27A67205A9893EBE03D03B799B8B56 
{
	int32_t ___keyword;
	Length_t90BB06D47DD6DB461ED21BD3E3241FAB6C824256 ___offset;
};
struct BackgroundSize_t809883E2D7BB1D8D85B4C3E1DBE189F187DB25E7 
{
	int32_t ___m_SizeType;
	Length_t90BB06D47DD6DB461ED21BD3E3241FAB6C824256 ___m_X;
	Length_t90BB06D47DD6DB461ED21BD3E3241FAB6C824256 ___m_Y;
};
struct Rotate_tE965CA0281A547AB38B881A3416FF97756D3F4D7 
{
	Angle_t0229F612898D65B3CC646C40A32D93D8A33C1DFC ___m_Angle;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_Axis;
	bool ___m_IsNone;
};
struct Rotate_tE965CA0281A547AB38B881A3416FF97756D3F4D7_marshaled_pinvoke
{
	Angle_t0229F612898D65B3CC646C40A32D93D8A33C1DFC ___m_Angle;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_Axis;
	int32_t ___m_IsNone;
};
struct Rotate_tE965CA0281A547AB38B881A3416FF97756D3F4D7_marshaled_com
{
	Angle_t0229F612898D65B3CC646C40A32D93D8A33C1DFC ___m_Angle;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___m_Axis;
	int32_t ___m_IsNone;
};
struct StyleBackgroundRepeat_t38B84958D5608FAA86B06F513716444EA06DB866 
{
	BackgroundRepeat_t446EC7315DED2C6822F1047B7587C3018BFB277F ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleLength_tF02B24735FC88BE29BEB36F7A87709CA28AF72D8 
{
	Length_t90BB06D47DD6DB461ED21BD3E3241FAB6C824256 ___m_Value;
	int32_t ___m_Keyword;
};
struct TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A 
{
	Length_t90BB06D47DD6DB461ED21BD3E3241FAB6C824256 ___m_MinSize;
	Length_t90BB06D47DD6DB461ED21BD3E3241FAB6C824256 ___m_MaxSize;
	int32_t ___m_Mode;
};
struct TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502 
{
	Length_t90BB06D47DD6DB461ED21BD3E3241FAB6C824256 ___m_X;
	Length_t90BB06D47DD6DB461ED21BD3E3241FAB6C824256 ___m_Y;
	float ___m_Z;
};
struct Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E 
{
	Length_t90BB06D47DD6DB461ED21BD3E3241FAB6C824256 ___m_X;
	Length_t90BB06D47DD6DB461ED21BD3E3241FAB6C824256 ___m_Y;
	float ___m_Z;
	bool ___m_isNone;
};
struct Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E_marshaled_pinvoke
{
	Length_t90BB06D47DD6DB461ED21BD3E3241FAB6C824256 ___m_X;
	Length_t90BB06D47DD6DB461ED21BD3E3241FAB6C824256 ___m_Y;
	float ___m_Z;
	int32_t ___m_isNone;
};
struct Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E_marshaled_com
{
	Length_t90BB06D47DD6DB461ED21BD3E3241FAB6C824256 ___m_X;
	Length_t90BB06D47DD6DB461ED21BD3E3241FAB6C824256 ___m_Y;
	float ___m_Z;
	int32_t ___m_isNone;
};
struct TypeConverter_2_t73501A4CF3B35838D78DF2D56FF13675BEADC04B  : public MulticastDelegate_t
{
};
struct TypeConverter_2_t26D60543337DCCA819FD538D85F40D86762DB0F2  : public MulticastDelegate_t
{
};
struct TypeConverter_2_tC8DC9C48FBE571CF2E75D0324F34468EACBEB008  : public MulticastDelegate_t
{
};
struct FilterFunction_t32E0707BD9D9F770A2A7578985A5C163FC1AAEFF 
{
	int32_t ___m_Type;
	FixedBuffer4_1_tFD261E0E1A5ECEFC54C0B0B89FA6BFEE477E4D8C ___m_Parameters;
	int32_t ___m_ParameterCount;
	FilterFunctionDefinition_tFE41DB19FFB74F4D2B54BF44D1D2051B57FC82F2* ___m_CustomDefinition;
};
struct FilterFunction_t32E0707BD9D9F770A2A7578985A5C163FC1AAEFF_marshaled_pinvoke
{
	int32_t ___m_Type;
	FixedBuffer4_1_tFD261E0E1A5ECEFC54C0B0B89FA6BFEE477E4D8C ___m_Parameters;
	int32_t ___m_ParameterCount;
	FilterFunctionDefinition_tFE41DB19FFB74F4D2B54BF44D1D2051B57FC82F2* ___m_CustomDefinition;
};
struct FilterFunction_t32E0707BD9D9F770A2A7578985A5C163FC1AAEFF_marshaled_com
{
	int32_t ___m_Type;
	FixedBuffer4_1_tFD261E0E1A5ECEFC54C0B0B89FA6BFEE477E4D8C ___m_Parameters;
	int32_t ___m_ParameterCount;
	FilterFunctionDefinition_tFE41DB19FFB74F4D2B54BF44D1D2051B57FC82F2* ___m_CustomDefinition;
};
struct StyleBackgroundPosition_t707AF9D66EF808C1B1DE174CAB623D97A653C3F3 
{
	BackgroundPosition_tF0822B29FC27A67205A9893EBE03D03B799B8B56 ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleBackgroundSize_t0904929E2E236696CEC8DBD4B1082E8313F84008 
{
	BackgroundSize_t809883E2D7BB1D8D85B4C3E1DBE189F187DB25E7 ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B 
{
	Rotate_tE965CA0281A547AB38B881A3416FF97756D3F4D7 ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B_marshaled_pinvoke
{
	Rotate_tE965CA0281A547AB38B881A3416FF97756D3F4D7_marshaled_pinvoke ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B_marshaled_com
{
	Rotate_tE965CA0281A547AB38B881A3416FF97756D3F4D7_marshaled_com ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A 
{
	int32_t ___m_Keyword;
	TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A ___m_Value;
};
struct StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6 
{
	TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502 ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089 
{
	Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089_marshaled_pinvoke
{
	Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E_marshaled_pinvoke ___m_Value;
	int32_t ___m_Keyword;
};
struct StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089_marshaled_com
{
	Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E_marshaled_com ___m_Value;
	int32_t ___m_Keyword;
};
struct TypeConverter_2_t0D424B5552ED05121DAA8FBC96BFA5B5D7C25841  : public MulticastDelegate_t
{
};
struct TypeConverter_2_t77EBC7DE8779DBFC8C888CCCBA1C57A1900F8D0E  : public MulticastDelegate_t
{
};
struct TypeConverter_2_t3B4B4ED61AFE2B4C7E58725FA7AE976658EDFC5F  : public MulticastDelegate_t
{
};
struct TypeConverter_2_tE6C2466AFC58085EAE6299B76802C78CC1C80F0D  : public MulticastDelegate_t
{
};
struct String_t_StaticFields
{
	String_t* ___Empty;
};
struct TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticFields
{
	ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426 ___s_GlobalConverters;
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	String_t* ___TrueString;
	String_t* ___FalseString;
};
struct Char_t521A6F19B456D956AF452D926C32709DC03D6B17_StaticFields
{
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___s_categoryForLatin1;
};
struct DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D_StaticFields
{
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ___s_daysToMonth365;
	Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C* ___s_daysToMonth366;
	DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D ___MinValue;
	DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D ___MaxValue;
	DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D ___UnixEpoch;
};
struct Guid_t_StaticFields
{
	Guid_t ___Empty;
};
struct TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_StaticFields
{
	TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___Zero;
	TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___MaxValue;
	TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___MinValue;
};
struct Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_StaticFields
{
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___zeroVector;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___oneVector;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___upVector;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___downVector;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___leftVector;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___rightVector;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___positiveInfinityVector;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 ___negativeInfinityVector;
};
struct Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_StaticFields
{
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___zeroVector;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___oneVector;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___upVector;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___downVector;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___leftVector;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___rightVector;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___forwardVector;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___backVector;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___positiveInfinityVector;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 ___negativeInfinityVector;
};
struct Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_StaticFields
{
	Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___s_Zero;
	Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___s_One;
	Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___s_Up;
	Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___s_Down;
	Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___s_Left;
	Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___s_Right;
	Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___s_Forward;
	Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 ___s_Back;
};
struct Angle_t0229F612898D65B3CC646C40A32D93D8A33C1DFC_StaticFields
{
	Dictionary_2_t29FB78C9E5DF443E2A5880E4E9B7C86E516670E0* ___s_AngleUnitLookup;
};
struct Type_t_StaticFields
{
	Binder_t91BFCE95A7057FADF4D8A1A342AFE52872246235* ___s_defaultBinder;
	Il2CppChar ___Delimiter;
	TypeU5BU5D_t97234E1129B564EB38B8D85CAC2AD8B5B9522FFB* ___EmptyTypes;
	RuntimeObject* ___Missing;
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterAttribute;
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterName;
	MemberFilter_tF644F1AE82F611B677CE1964D5A3277DDA21D553* ___FilterNameIgnoreCase;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif


IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471 TypeConverter_2_Invoke_mC00EB2E2FCBECD90D43B086E367A5588CFB7AF75_gshared_inline (TypeConverter_2_tF89582388D90E6733D9336D56E72113181F8C35B* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471_m59DB4753957EB5BA30C48FE1C694E34BF7830C98_gshared (Il2CppSharedGenericObject** ___0_source, StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471_mC96BA17CB5BF6E8B6AF14E6C0A26154D7811E722_gshared (Il2CppSharedGenericObject** ___0_source, StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471_m5B1AD86BD6C6B2FC15C76AE6E8B16344BEFE7A3C_gshared (Il2CppSharedGenericObject** ___0_source, StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471_mC7A632F3E2D58B15813E5616DFC851B3410FBA31_gshared (Il2CppSharedGenericObject* ___0_source, StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF TypeConverter_2_Invoke_m9364011AA418E118526924552C4365CDBE204F0C_gshared_inline (TypeConverter_2_t6639570A10ABBF2F824E8BC88925BA36914DC1C7* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF_m78F73284BBAFADA319C7804E792D97C79B486CC2_gshared (Il2CppSharedGenericObject** ___0_source, StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF_m8710A9FFE30405668A0F172E1A2972301613D0B4_gshared (Il2CppSharedGenericObject** ___0_source, StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF_mE931009931A256BCE221B6717D0E9068571475C4_gshared (Il2CppSharedGenericObject** ___0_source, StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF_mE5C6E0BB516B4472F1806B58F71AAF258415E9D5_gshared (Il2CppSharedGenericObject* ___0_source, StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906 TypeConverter_2_Invoke_m8BAF3CB8DC77C7156495925FCEB4DD4EBD2A166D_gshared_inline (TypeConverter_2_t14B52AF1258A5A9C9C7C40B585BCC796EB89546E* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906_mF340730BADE7CD1655772A73E270A945D0892216_gshared (Il2CppSharedGenericObject** ___0_source, StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906_m5C9EC8D76409E9B6B1CA0A23CA75F89E39E2F80D_gshared (Il2CppSharedGenericObject** ___0_source, StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906_mCBE71A84055551D9FF60862B884C28F1E9782E83_gshared (Il2CppSharedGenericObject** ___0_source, StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906_mE081F767B5982BA86FA384B5F73E377754FEA1ED_gshared (Il2CppSharedGenericObject* ___0_source, StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B TypeConverter_2_Invoke_m2E33325E79FFF74B5F0696488BE57DC3D7DCB412_gshared_inline (TypeConverter_2_t0D424B5552ED05121DAA8FBC96BFA5B5D7C25841* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B_mEDFD14C52E172CCF4A61A04A9A094E9D6F7DB156_gshared (Il2CppSharedGenericObject** ___0_source, StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B_mEF1C101D1CB9BAAD6F887252CEEAB935DD02443F_gshared (Il2CppSharedGenericObject** ___0_source, StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B_mA47EF357DF4978A62F798ABD17920EA9EF28A241_gshared (Il2CppSharedGenericObject** ___0_source, StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B_m7BF85D612CF7C2D1E96964A290DBFD9D384AF493_gshared (Il2CppSharedGenericObject* ___0_source, StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC TypeConverter_2_Invoke_m301828B6620219C395E629511178814425BBA544_gshared_inline (TypeConverter_2_t325870E3CF7DE93A02F5E359A73B09EE687F7764* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC_m61EB4AA6047F4BF2A299412C79F0BAE64EF8577C_gshared (Il2CppSharedGenericObject** ___0_source, StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC_m5221BCC9C76B1529CD3967FF3F7037B38BA59665_gshared (Il2CppSharedGenericObject** ___0_source, StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC_mE3243DEF7BCF96634BF3897EDE812C72D36C226E_gshared (Il2CppSharedGenericObject** ___0_source, StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC_m0A77200F22765DC6ED2ED451CC005E908F06A11C_gshared (Il2CppSharedGenericObject* ___0_source, StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A TypeConverter_2_Invoke_mDE9C8CB32A3B1147B5AFF244AB7647F2EE4C310E_gshared_inline (TypeConverter_2_t77EBC7DE8779DBFC8C888CCCBA1C57A1900F8D0E* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A_m03CDF717FFC10FA57D8FCB8AEF6475A0FDFC73FC_gshared (Il2CppSharedGenericObject** ___0_source, StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A_mFB30EDCEA7A892A3E41BF1CC21A9A18510955E88_gshared (Il2CppSharedGenericObject** ___0_source, StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A_m19E6B111B2D7BC7EE7CF6553C46525BB51F4120F_gshared (Il2CppSharedGenericObject** ___0_source, StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A_m853A450EC24CDBC2E14281CE2C04239CF7E7FA60_gshared (Il2CppSharedGenericObject* ___0_source, StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252 TypeConverter_2_Invoke_mBE4E53C83E451210FA4A9D332098E0DBD397DDFA_gshared_inline (TypeConverter_2_t2590D829276A4C224936EDAFCF1D1137DC63F062* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252_m36A599F60624F70FD50DCB07B16B9BA5BD7F6A98_gshared (Il2CppSharedGenericObject** ___0_source, StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252_m9359627757B7AA5BAEABF2E3733CA75250B71689_gshared (Il2CppSharedGenericObject** ___0_source, StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252_m92F5D0FB29637BCC654F196DB59AE83AB1503B37_gshared (Il2CppSharedGenericObject** ___0_source, StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252_mEE7F4A8F63991814B174D57FCF6FC2F496DF7EA5_gshared (Il2CppSharedGenericObject* ___0_source, StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6 TypeConverter_2_Invoke_mB032B3ECE8561B150D6ACFC6C00837DB7C97AD25_gshared_inline (TypeConverter_2_t3B4B4ED61AFE2B4C7E58725FA7AE976658EDFC5F* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6_mC70333DA7CA3AFF76D3E9574EE81479CE9BC2840_gshared (Il2CppSharedGenericObject** ___0_source, StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6_m59AB4830924D3EB4EF592D33AF615CDB18F04D17_gshared (Il2CppSharedGenericObject** ___0_source, StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6_mC010D90CA83E3F0856A54E04B37DCF13940AB474_gshared (Il2CppSharedGenericObject** ___0_source, StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6_m8399BB721318A07B2CB98B770031EFC5EF12E7F7_gshared (Il2CppSharedGenericObject* ___0_source, StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089 TypeConverter_2_Invoke_m3927B7CA3A864D22F9C90042FACFAD85E8470864_gshared_inline (TypeConverter_2_tE6C2466AFC58085EAE6299B76802C78CC1C80F0D* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089_mFCB591597B291D0DD02CFE098E32373927D39C14_gshared (Il2CppSharedGenericObject** ___0_source, StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089_m7F86A21E8CB43CB0D4B5C5B1CFC38574D3A3C0C1_gshared (Il2CppSharedGenericObject** ___0_source, StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089_m8F64884E8AD78172136BC920DCF5CAF162D57F12_gshared (Il2CppSharedGenericObject** ___0_source, StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089_m4EB0464CDB4975842B63C67462BDBB01612FABCB_gshared (Il2CppSharedGenericObject* ___0_source, StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5 TypeConverter_2_Invoke_m66AB21C3C933003F4B10DB738B579AFF92767A3D_gshared_inline (TypeConverter_2_tE2027A3B32E1BB438286300A403B88A772D4E99F* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5_m564B93B9344A01B1A52075D1912BEF406EC84E87_gshared (Il2CppSharedGenericObject** ___0_source, StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5_m3227677FE5E7EDA4602AF0D303E44A200D8AA66E_gshared (Il2CppSharedGenericObject** ___0_source, StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5_m6D805B2A00A84AC4C86C865C3B0460DC556F4E42_gshared (Il2CppSharedGenericObject** ___0_source, StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5_mA1B091C8410E7B6B77A87FB8193CA30DC21D4F7D_gshared (Il2CppSharedGenericObject* ___0_source, StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A TypeConverter_2_Invoke_mE56444FC16A71452E074A8C12A28AEE28120D830_gshared_inline (TypeConverter_2_t73501A4CF3B35838D78DF2D56FF13675BEADC04B* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisTextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A_mEEB83B2B4E5614452D4D2A8725EB634658C31DBC_gshared (Il2CppSharedGenericObject** ___0_source, TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisTextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A_mBC72FAD802D2847DCD9F992F3F55C241F65D44F1_gshared (Il2CppSharedGenericObject** ___0_source, TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisTextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A_m88C9AF679301ABB958D4D24E822A33521E08FFD3_gshared (Il2CppSharedGenericObject** ___0_source, TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisTextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A_mAF37628D99B7AE42B9420533D24C7F5F7B94D986_gshared (Il2CppSharedGenericObject* ___0_source, TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05 TypeConverter_2_Invoke_m5EFB8A4B526E5038BBEB12C50358AA67406DC302_gshared_inline (TypeConverter_2_tC0A832D8646E8260644D66DD7FA213AC57484831* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisTextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05_m8E83833ECA82E697F7024DC7070AC6128A018B76_gshared (Il2CppSharedGenericObject** ___0_source, TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisTextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05_m7EADBF9FD32CFE1F86F36BAF4839C307E7B54042_gshared (Il2CppSharedGenericObject** ___0_source, TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisTextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05_m77C51931C4EDB1902C16349B4C4D9BC785E6DEC0_gshared (Il2CppSharedGenericObject** ___0_source, TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisTextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05_m05759354955D3A449C3EB327B9D0FC2995D78A16_gshared (Il2CppSharedGenericObject* ___0_source, TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A TypeConverter_2_Invoke_m8A30F6853F5EE6FCFDE935B43D200CCAA09136B4_gshared_inline (TypeConverter_2_t0A5CBF00DFB82526AEB7B2DFEF71CA4F4807581E* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisTimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_mABD8E4CDEF3C53E49935B66E044F8D4A232A3D03_gshared (Il2CppSharedGenericObject** ___0_source, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisTimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_m069CFAFE812619C0986B6D70996F30B2A4F8B9BC_gshared (Il2CppSharedGenericObject** ___0_source, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisTimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_mA65027452747D38D73A877E1C21175A015F9177A_gshared (Il2CppSharedGenericObject** ___0_source, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisTimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_mCE6A94094E0147E3D6D83D9EED5C942FA998BBFC_gshared (Il2CppSharedGenericObject* ___0_source, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E TypeConverter_2_Invoke_mDFB5642B7FB6B4442DBC14B2F31EF44601F04D38_gshared_inline (TypeConverter_2_tBA10E08FB2B7207E85EAB1039CE76A8D80224B20* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisTimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E_m1B1B4E79A79CB4606C4FCD10011C3C1E9C491B4F_gshared (Il2CppSharedGenericObject** ___0_source, TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisTimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E_mDC3DBAD282E45562925459BB094157FE8D7A39B1_gshared (Il2CppSharedGenericObject** ___0_source, TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisTimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E_m5050A815DCF77923C0D3454F0E2464A0CC9C2D12_gshared (Il2CppSharedGenericObject** ___0_source, TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisTimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E_m890F9B74999D7F62E686CB9028C19252CF5B3162_gshared (Il2CppSharedGenericObject* ___0_source, TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502 TypeConverter_2_Invoke_mCE58430324F9B994275CA0432152E6690C870493_gshared_inline (TypeConverter_2_t26D60543337DCCA819FD538D85F40D86762DB0F2* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisTransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502_m86DA4A09ED739EC95D08078C2A68B5D3B2331B4D_gshared (Il2CppSharedGenericObject** ___0_source, TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisTransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502_m43E97D6A9927E5D80F447A939DECC30242168E99_gshared (Il2CppSharedGenericObject** ___0_source, TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisTransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502_mC73284DDA65769315166572B6F9EBBB09FD66BAC_gshared (Il2CppSharedGenericObject** ___0_source, TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisTransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502_mF9CB9E3DF63B70278C7644C14E87765DFF86202E_gshared (Il2CppSharedGenericObject* ___0_source, TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E TypeConverter_2_Invoke_mD793CD9960E098A5D8B04701404212678B3C4087_gshared_inline (TypeConverter_2_tC8DC9C48FBE571CF2E75D0324F34468EACBEB008* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisTranslate_t494F6E802F8A640D67819C9D26BE62DED1218A8E_m59519C17558F8D8E4F1351404BEA83B969C19120_gshared (Il2CppSharedGenericObject** ___0_source, Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisTranslate_t494F6E802F8A640D67819C9D26BE62DED1218A8E_mE693B7D7A19E1DC6276F1A46097436590B6C96E4_gshared (Il2CppSharedGenericObject** ___0_source, Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisTranslate_t494F6E802F8A640D67819C9D26BE62DED1218A8E_mF43635F25DDF8116F489001592D21F5AC5264A15_gshared (Il2CppSharedGenericObject** ___0_source, Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisTranslate_t494F6E802F8A640D67819C9D26BE62DED1218A8E_m15BCEE9792C8945FDE5437EC42A3AEC4C84FDC99_gshared (Il2CppSharedGenericObject* ___0_source, Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint16_t TypeConverter_2_Invoke_m66222088B81B0479C4FAED81A6E115C2078D89A2_gshared_inline (TypeConverter_2_t7104BAD86AB01041A6B4CFA05DD8A0CF7B316EAE* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisUInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_mDA8A246BC062B5634F667D514235205969506D53_gshared (Il2CppSharedGenericObject** ___0_source, uint16_t* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisUInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_m65E9FB7FA0D01A0CD52BDA1F0FD39CE635D5CF9B_gshared (Il2CppSharedGenericObject** ___0_source, uint16_t* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisUInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_m7044D1087F56C3448C4455C14F31DD12DFA2A2FF_gshared (Il2CppSharedGenericObject** ___0_source, uint16_t* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisUInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_m0CF638A658A95329981CFE92A200F9F026CC88BF_gshared (Il2CppSharedGenericObject* ___0_source, uint16_t* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint32_t TypeConverter_2_Invoke_mCBE8A03AC2A93E11AC276C8AB69B069E2DC24E9F_gshared_inline (TypeConverter_2_t987BA7DD2FE661C6A4CD1CE7F398720A1A912CDB* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_mC57548E2FBB7801ADCA39608D4B49D6B97974514_gshared (Il2CppSharedGenericObject** ___0_source, uint32_t* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_m06E5488A389513768C081F56CFDE78AC028D9C43_gshared (Il2CppSharedGenericObject** ___0_source, uint32_t* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_m55BEAE3C511900D8ED0BA0D28D3F54CE3676D84C_gshared (Il2CppSharedGenericObject** ___0_source, uint32_t* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_mC43EF7862142C0A1290BAC84D392D044737CAF02_gshared (Il2CppSharedGenericObject* ___0_source, uint32_t* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint64_t TypeConverter_2_Invoke_mEA8D3ECFB70460557F24848D00C2A296D047A36F_gshared_inline (TypeConverter_2_tFE7942B61544B13EC61F654A379BB8C5C19E478F* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisUInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_mBB921111FF38E5C99FF61AE3BE80009C2E022239_gshared (Il2CppSharedGenericObject** ___0_source, uint64_t* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisUInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_m032089056E1895100A9FB554517491D88FD1A89A_gshared (Il2CppSharedGenericObject** ___0_source, uint64_t* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisUInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_m6048AB2AE3D1B37759345D9381A4288919B5C3D6_gshared (Il2CppSharedGenericObject** ___0_source, uint64_t* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisUInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_mB1C7ABF4F0D89B6AFF2CC47A8C61E42904145D05_gshared (Il2CppSharedGenericObject* ___0_source, uint64_t* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 TypeConverter_2_Invoke_m49AE9030B92C77BF35406171E80F83866E190EEB_gshared_inline (TypeConverter_2_t4C7D6F1114B9EFC390F0FE6F2860EDC1E7DF3049* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisVector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_m2CF3D0A8B3D448DC8DC9920EAB7DD7F7294385EF_gshared (Il2CppSharedGenericObject** ___0_source, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisVector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_mBC9E99471BC4B1516C14CA600EBF62C219CDE927_gshared (Il2CppSharedGenericObject** ___0_source, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisVector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_mF12E9E30A8C88ED1C3CDC1ABB42D399DB55766B5_gshared (Il2CppSharedGenericObject** ___0_source, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisVector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_mEAC9854D622F8E0FCDE60F2FD1E880F17E1D98BD_gshared (Il2CppSharedGenericObject* ___0_source, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 TypeConverter_2_Invoke_m9A7F8EB799C5DB7CC4A9461CF3A66B1A424F189D_gshared_inline (TypeConverter_2_tA9C93925BAFC7D4786356A2B45762EB2575F3986* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisVector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_m49EFB846487E3484F55E93EA59F1C8680F01C2A3_gshared (Il2CppSharedGenericObject** ___0_source, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisVector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_mA6528517794E3114FFAB96CC8420747CD0F9DCEF_gshared (Il2CppSharedGenericObject** ___0_source, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisVector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_m230B481A8A76B8DC7B7A99CDEEF2E6673CE432C8_gshared (Il2CppSharedGenericObject** ___0_source, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisVector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_m304562AB878726D52E63977FEBBF8A8E1784C510_gshared (Il2CppSharedGenericObject* ___0_source, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 TypeConverter_2_Invoke_m88BD1040FEFBC4E99093EA05FF231808CAFDB905_gshared_inline (TypeConverter_2_t2257368AB189DB95AF22DD35774E8FEB55C630BB* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m6157AA92D4D7AAB292C81468B7FFE47C97235CDD_gshared (Il2CppSharedGenericObject** ___0_source, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_mCE9040441F7B72DA914C67E892AB79C88A378C16_gshared (Il2CppSharedGenericObject** ___0_source, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m2AF19A10CED2896DA749F3489173964612DDE1C1_gshared (Il2CppSharedGenericObject** ___0_source, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m300E03EBD0D44EC7E31CEDAE2EDDBCD68477B15A_gshared (Il2CppSharedGenericObject* ___0_source, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Il2CppSharedGenericObject* TypeConverter_2_Invoke_mF0FFFFF940DA8BB84CBB0B4BD67E875750ADA97C_gshared_inline (TypeConverter_2_t0525BA89BAB435F8C9F2EEF9023F9BCB7ABE80A1* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Il2CppSharedGenericObject** UnsafeUtility_As_TisIl2CppSharedGenericObject_TisIl2CppSharedGenericObject_m7E01BE5B3130A632C43D1F86A8781C30A93D3DCF_gshared_inline (Il2CppSharedGenericObject** ___0_from, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisIl2CppSharedGenericObject_m8343A93DAE3091C3CD02BAC3040AB4BB095DB4ED_gshared (Il2CppSharedGenericObject** ___0_source, Il2CppSharedGenericObject** ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisIl2CppSharedGenericObject_m034C149F56406F6438D59B3B56CE2DAD125E75D9_gshared (Il2CppSharedGenericObject** ___0_source, Il2CppSharedGenericObject** ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisIl2CppSharedGenericObject_mDAB6678DE2D56B194CD5E28F0EE09524A56EB17C_gshared (Il2CppSharedGenericObject** ___0_source, Il2CppSharedGenericObject** ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisIl2CppSharedGenericObject_m69CA52F1857A6F0CC726661F95B30610A2A5A056_gshared (Il2CppSharedGenericObject* ___0_source, Il2CppSharedGenericObject** ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t TypeConverter_2_Invoke_m7765922B627FE0A4912228208A85C752498BDC44_gshared_inline (TypeConverter_2_t81D4A80534427AD7BC452191F15131144F2FF763* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_m316683D4F266C24D4C1495CD004BDC50F3AE3827_gshared (Il2CppSharedGenericObject** ___0_source, int32_t* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_m42DE9E0B9A4D56213CE7044948F570C5E27289F2_gshared (Il2CppSharedGenericObject** ___0_source, int32_t* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_mD67DFE8D393E6CC55EB59A3C824DD7F8FEBDA6C9_gshared (Il2CppSharedGenericObject** ___0_source, int32_t* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_m0BDE3F76A27AF8EE49D883FDA385E6DC4AED439D_gshared (Il2CppSharedGenericObject* ___0_source, int32_t* ___1_destination, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t* UnsafeUtility_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_m9AEA7CA3ED58CAAF5CC970EF8B1182B9DC69D464_gshared_inline (bool* ___0_from, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Il2CppFullySharedGenericAny* UnsafeUtilityInternal_As_TisIl2CppFullySharedGenericAny_TisIl2CppFullySharedGenericAny_mE1CA751887466B801BE69083C2B0EA3EDE41FF9B_fshared_inline (Il2CppFullySharedGenericAny* ___0_from, const RuntimeMethod* method) ;

IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Type_t* Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57 (RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B ___0_handle, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* __this, Type_t* ___0_source, Type_t* ___1_destination, Delegate_t** ___2_converter, const RuntimeMethod* method) ;
inline StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471 TypeConverter_2_Invoke_mC00EB2E2FCBECD90D43B086E367A5588CFB7AF75_inline (TypeConverter_2_tF89582388D90E6733D9336D56E72113181F8C35B* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method)
{
	return ((  StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471 (*) (TypeConverter_2_tF89582388D90E6733D9336D56E72113181F8C35B*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConverter_2_Invoke_mC00EB2E2FCBECD90D43B086E367A5588CFB7AF75_gshared_inline)(__this, ___0_value, method);
}
inline bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471_m59DB4753957EB5BA30C48FE1C694E34BF7830C98 (Il2CppSharedGenericObject** ___0_source, StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471*, const RuntimeMethod*))PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471_m59DB4753957EB5BA30C48FE1C694E34BF7830C98_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471_mC96BA17CB5BF6E8B6AF14E6C0A26154D7811E722 (Il2CppSharedGenericObject** ___0_source, StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471*, const RuntimeMethod*))TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471_mC96BA17CB5BF6E8B6AF14E6C0A26154D7811E722_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471_m5B1AD86BD6C6B2FC15C76AE6E8B16344BEFE7A3C (Il2CppSharedGenericObject** ___0_source, StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471*, const RuntimeMethod*))TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471_m5B1AD86BD6C6B2FC15C76AE6E8B16344BEFE7A3C_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471_mC7A632F3E2D58B15813E5616DFC851B3410FBA31 (Il2CppSharedGenericObject* ___0_source, StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject*, StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471*, const RuntimeMethod*))TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471_mC7A632F3E2D58B15813E5616DFC851B3410FBA31_gshared)(___0_source, ___1_destination, method);
}
inline StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF TypeConverter_2_Invoke_m9364011AA418E118526924552C4365CDBE204F0C_inline (TypeConverter_2_t6639570A10ABBF2F824E8BC88925BA36914DC1C7* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method)
{
	return ((  StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF (*) (TypeConverter_2_t6639570A10ABBF2F824E8BC88925BA36914DC1C7*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConverter_2_Invoke_m9364011AA418E118526924552C4365CDBE204F0C_gshared_inline)(__this, ___0_value, method);
}
inline bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF_m78F73284BBAFADA319C7804E792D97C79B486CC2 (Il2CppSharedGenericObject** ___0_source, StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF*, const RuntimeMethod*))PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF_m78F73284BBAFADA319C7804E792D97C79B486CC2_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF_m8710A9FFE30405668A0F172E1A2972301613D0B4 (Il2CppSharedGenericObject** ___0_source, StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF*, const RuntimeMethod*))TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF_m8710A9FFE30405668A0F172E1A2972301613D0B4_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF_mE931009931A256BCE221B6717D0E9068571475C4 (Il2CppSharedGenericObject** ___0_source, StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF*, const RuntimeMethod*))TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF_mE931009931A256BCE221B6717D0E9068571475C4_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF_mE5C6E0BB516B4472F1806B58F71AAF258415E9D5 (Il2CppSharedGenericObject* ___0_source, StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject*, StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF*, const RuntimeMethod*))TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF_mE5C6E0BB516B4472F1806B58F71AAF258415E9D5_gshared)(___0_source, ___1_destination, method);
}
inline StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906 TypeConverter_2_Invoke_m8BAF3CB8DC77C7156495925FCEB4DD4EBD2A166D_inline (TypeConverter_2_t14B52AF1258A5A9C9C7C40B585BCC796EB89546E* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method)
{
	return ((  StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906 (*) (TypeConverter_2_t14B52AF1258A5A9C9C7C40B585BCC796EB89546E*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConverter_2_Invoke_m8BAF3CB8DC77C7156495925FCEB4DD4EBD2A166D_gshared_inline)(__this, ___0_value, method);
}
inline bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906_mF340730BADE7CD1655772A73E270A945D0892216 (Il2CppSharedGenericObject** ___0_source, StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906*, const RuntimeMethod*))PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906_mF340730BADE7CD1655772A73E270A945D0892216_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906_m5C9EC8D76409E9B6B1CA0A23CA75F89E39E2F80D (Il2CppSharedGenericObject** ___0_source, StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906*, const RuntimeMethod*))TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906_m5C9EC8D76409E9B6B1CA0A23CA75F89E39E2F80D_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906_mCBE71A84055551D9FF60862B884C28F1E9782E83 (Il2CppSharedGenericObject** ___0_source, StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906*, const RuntimeMethod*))TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906_mCBE71A84055551D9FF60862B884C28F1E9782E83_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906_mE081F767B5982BA86FA384B5F73E377754FEA1ED (Il2CppSharedGenericObject* ___0_source, StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject*, StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906*, const RuntimeMethod*))TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906_mE081F767B5982BA86FA384B5F73E377754FEA1ED_gshared)(___0_source, ___1_destination, method);
}
inline StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B TypeConverter_2_Invoke_m2E33325E79FFF74B5F0696488BE57DC3D7DCB412_inline (TypeConverter_2_t0D424B5552ED05121DAA8FBC96BFA5B5D7C25841* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method)
{
	return ((  StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B (*) (TypeConverter_2_t0D424B5552ED05121DAA8FBC96BFA5B5D7C25841*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConverter_2_Invoke_m2E33325E79FFF74B5F0696488BE57DC3D7DCB412_gshared_inline)(__this, ___0_value, method);
}
inline bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B_mEDFD14C52E172CCF4A61A04A9A094E9D6F7DB156 (Il2CppSharedGenericObject** ___0_source, StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B*, const RuntimeMethod*))PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B_mEDFD14C52E172CCF4A61A04A9A094E9D6F7DB156_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B_mEF1C101D1CB9BAAD6F887252CEEAB935DD02443F (Il2CppSharedGenericObject** ___0_source, StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B*, const RuntimeMethod*))TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B_mEF1C101D1CB9BAAD6F887252CEEAB935DD02443F_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B_mA47EF357DF4978A62F798ABD17920EA9EF28A241 (Il2CppSharedGenericObject** ___0_source, StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B*, const RuntimeMethod*))TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B_mA47EF357DF4978A62F798ABD17920EA9EF28A241_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B_m7BF85D612CF7C2D1E96964A290DBFD9D384AF493 (Il2CppSharedGenericObject* ___0_source, StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject*, StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B*, const RuntimeMethod*))TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B_m7BF85D612CF7C2D1E96964A290DBFD9D384AF493_gshared)(___0_source, ___1_destination, method);
}
inline StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC TypeConverter_2_Invoke_m301828B6620219C395E629511178814425BBA544_inline (TypeConverter_2_t325870E3CF7DE93A02F5E359A73B09EE687F7764* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method)
{
	return ((  StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC (*) (TypeConverter_2_t325870E3CF7DE93A02F5E359A73B09EE687F7764*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConverter_2_Invoke_m301828B6620219C395E629511178814425BBA544_gshared_inline)(__this, ___0_value, method);
}
inline bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC_m61EB4AA6047F4BF2A299412C79F0BAE64EF8577C (Il2CppSharedGenericObject** ___0_source, StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC*, const RuntimeMethod*))PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC_m61EB4AA6047F4BF2A299412C79F0BAE64EF8577C_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC_m5221BCC9C76B1529CD3967FF3F7037B38BA59665 (Il2CppSharedGenericObject** ___0_source, StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC*, const RuntimeMethod*))TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC_m5221BCC9C76B1529CD3967FF3F7037B38BA59665_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC_mE3243DEF7BCF96634BF3897EDE812C72D36C226E (Il2CppSharedGenericObject** ___0_source, StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC*, const RuntimeMethod*))TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC_mE3243DEF7BCF96634BF3897EDE812C72D36C226E_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC_m0A77200F22765DC6ED2ED451CC005E908F06A11C (Il2CppSharedGenericObject* ___0_source, StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject*, StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC*, const RuntimeMethod*))TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC_m0A77200F22765DC6ED2ED451CC005E908F06A11C_gshared)(___0_source, ___1_destination, method);
}
inline StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A TypeConverter_2_Invoke_mDE9C8CB32A3B1147B5AFF244AB7647F2EE4C310E_inline (TypeConverter_2_t77EBC7DE8779DBFC8C888CCCBA1C57A1900F8D0E* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method)
{
	return ((  StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A (*) (TypeConverter_2_t77EBC7DE8779DBFC8C888CCCBA1C57A1900F8D0E*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConverter_2_Invoke_mDE9C8CB32A3B1147B5AFF244AB7647F2EE4C310E_gshared_inline)(__this, ___0_value, method);
}
inline bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A_m03CDF717FFC10FA57D8FCB8AEF6475A0FDFC73FC (Il2CppSharedGenericObject** ___0_source, StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A*, const RuntimeMethod*))PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A_m03CDF717FFC10FA57D8FCB8AEF6475A0FDFC73FC_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A_mFB30EDCEA7A892A3E41BF1CC21A9A18510955E88 (Il2CppSharedGenericObject** ___0_source, StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A*, const RuntimeMethod*))TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A_mFB30EDCEA7A892A3E41BF1CC21A9A18510955E88_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A_m19E6B111B2D7BC7EE7CF6553C46525BB51F4120F (Il2CppSharedGenericObject** ___0_source, StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A*, const RuntimeMethod*))TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A_m19E6B111B2D7BC7EE7CF6553C46525BB51F4120F_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A_m853A450EC24CDBC2E14281CE2C04239CF7E7FA60 (Il2CppSharedGenericObject* ___0_source, StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject*, StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A*, const RuntimeMethod*))TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A_m853A450EC24CDBC2E14281CE2C04239CF7E7FA60_gshared)(___0_source, ___1_destination, method);
}
inline StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252 TypeConverter_2_Invoke_mBE4E53C83E451210FA4A9D332098E0DBD397DDFA_inline (TypeConverter_2_t2590D829276A4C224936EDAFCF1D1137DC63F062* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method)
{
	return ((  StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252 (*) (TypeConverter_2_t2590D829276A4C224936EDAFCF1D1137DC63F062*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConverter_2_Invoke_mBE4E53C83E451210FA4A9D332098E0DBD397DDFA_gshared_inline)(__this, ___0_value, method);
}
inline bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252_m36A599F60624F70FD50DCB07B16B9BA5BD7F6A98 (Il2CppSharedGenericObject** ___0_source, StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252*, const RuntimeMethod*))PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252_m36A599F60624F70FD50DCB07B16B9BA5BD7F6A98_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252_m9359627757B7AA5BAEABF2E3733CA75250B71689 (Il2CppSharedGenericObject** ___0_source, StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252*, const RuntimeMethod*))TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252_m9359627757B7AA5BAEABF2E3733CA75250B71689_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252_m92F5D0FB29637BCC654F196DB59AE83AB1503B37 (Il2CppSharedGenericObject** ___0_source, StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252*, const RuntimeMethod*))TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252_m92F5D0FB29637BCC654F196DB59AE83AB1503B37_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252_mEE7F4A8F63991814B174D57FCF6FC2F496DF7EA5 (Il2CppSharedGenericObject* ___0_source, StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject*, StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252*, const RuntimeMethod*))TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252_mEE7F4A8F63991814B174D57FCF6FC2F496DF7EA5_gshared)(___0_source, ___1_destination, method);
}
inline StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6 TypeConverter_2_Invoke_mB032B3ECE8561B150D6ACFC6C00837DB7C97AD25_inline (TypeConverter_2_t3B4B4ED61AFE2B4C7E58725FA7AE976658EDFC5F* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method)
{
	return ((  StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6 (*) (TypeConverter_2_t3B4B4ED61AFE2B4C7E58725FA7AE976658EDFC5F*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConverter_2_Invoke_mB032B3ECE8561B150D6ACFC6C00837DB7C97AD25_gshared_inline)(__this, ___0_value, method);
}
inline bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6_mC70333DA7CA3AFF76D3E9574EE81479CE9BC2840 (Il2CppSharedGenericObject** ___0_source, StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6*, const RuntimeMethod*))PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6_mC70333DA7CA3AFF76D3E9574EE81479CE9BC2840_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6_m59AB4830924D3EB4EF592D33AF615CDB18F04D17 (Il2CppSharedGenericObject** ___0_source, StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6*, const RuntimeMethod*))TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6_m59AB4830924D3EB4EF592D33AF615CDB18F04D17_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6_mC010D90CA83E3F0856A54E04B37DCF13940AB474 (Il2CppSharedGenericObject** ___0_source, StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6*, const RuntimeMethod*))TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6_mC010D90CA83E3F0856A54E04B37DCF13940AB474_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6_m8399BB721318A07B2CB98B770031EFC5EF12E7F7 (Il2CppSharedGenericObject* ___0_source, StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject*, StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6*, const RuntimeMethod*))TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6_m8399BB721318A07B2CB98B770031EFC5EF12E7F7_gshared)(___0_source, ___1_destination, method);
}
inline StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089 TypeConverter_2_Invoke_m3927B7CA3A864D22F9C90042FACFAD85E8470864_inline (TypeConverter_2_tE6C2466AFC58085EAE6299B76802C78CC1C80F0D* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method)
{
	return ((  StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089 (*) (TypeConverter_2_tE6C2466AFC58085EAE6299B76802C78CC1C80F0D*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConverter_2_Invoke_m3927B7CA3A864D22F9C90042FACFAD85E8470864_gshared_inline)(__this, ___0_value, method);
}
inline bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089_mFCB591597B291D0DD02CFE098E32373927D39C14 (Il2CppSharedGenericObject** ___0_source, StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089*, const RuntimeMethod*))PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089_mFCB591597B291D0DD02CFE098E32373927D39C14_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089_m7F86A21E8CB43CB0D4B5C5B1CFC38574D3A3C0C1 (Il2CppSharedGenericObject** ___0_source, StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089*, const RuntimeMethod*))TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089_m7F86A21E8CB43CB0D4B5C5B1CFC38574D3A3C0C1_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089_m8F64884E8AD78172136BC920DCF5CAF162D57F12 (Il2CppSharedGenericObject** ___0_source, StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089*, const RuntimeMethod*))TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089_m8F64884E8AD78172136BC920DCF5CAF162D57F12_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089_m4EB0464CDB4975842B63C67462BDBB01612FABCB (Il2CppSharedGenericObject* ___0_source, StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject*, StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089*, const RuntimeMethod*))TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089_m4EB0464CDB4975842B63C67462BDBB01612FABCB_gshared)(___0_source, ___1_destination, method);
}
inline StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5 TypeConverter_2_Invoke_m66AB21C3C933003F4B10DB738B579AFF92767A3D_inline (TypeConverter_2_tE2027A3B32E1BB438286300A403B88A772D4E99F* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method)
{
	return ((  StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5 (*) (TypeConverter_2_tE2027A3B32E1BB438286300A403B88A772D4E99F*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConverter_2_Invoke_m66AB21C3C933003F4B10DB738B579AFF92767A3D_gshared_inline)(__this, ___0_value, method);
}
inline bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5_m564B93B9344A01B1A52075D1912BEF406EC84E87 (Il2CppSharedGenericObject** ___0_source, StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5*, const RuntimeMethod*))PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5_m564B93B9344A01B1A52075D1912BEF406EC84E87_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5_m3227677FE5E7EDA4602AF0D303E44A200D8AA66E (Il2CppSharedGenericObject** ___0_source, StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5*, const RuntimeMethod*))TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5_m3227677FE5E7EDA4602AF0D303E44A200D8AA66E_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5_m6D805B2A00A84AC4C86C865C3B0460DC556F4E42 (Il2CppSharedGenericObject** ___0_source, StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5*, const RuntimeMethod*))TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5_m6D805B2A00A84AC4C86C865C3B0460DC556F4E42_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5_mA1B091C8410E7B6B77A87FB8193CA30DC21D4F7D (Il2CppSharedGenericObject* ___0_source, StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject*, StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5*, const RuntimeMethod*))TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5_mA1B091C8410E7B6B77A87FB8193CA30DC21D4F7D_gshared)(___0_source, ___1_destination, method);
}
inline TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A TypeConverter_2_Invoke_mE56444FC16A71452E074A8C12A28AEE28120D830_inline (TypeConverter_2_t73501A4CF3B35838D78DF2D56FF13675BEADC04B* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method)
{
	return ((  TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A (*) (TypeConverter_2_t73501A4CF3B35838D78DF2D56FF13675BEADC04B*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConverter_2_Invoke_mE56444FC16A71452E074A8C12A28AEE28120D830_gshared_inline)(__this, ___0_value, method);
}
inline bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisTextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A_mEEB83B2B4E5614452D4D2A8725EB634658C31DBC (Il2CppSharedGenericObject** ___0_source, TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A*, const RuntimeMethod*))PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisTextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A_mEEB83B2B4E5614452D4D2A8725EB634658C31DBC_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisTextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A_mBC72FAD802D2847DCD9F992F3F55C241F65D44F1 (Il2CppSharedGenericObject** ___0_source, TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A*, const RuntimeMethod*))TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisTextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A_mBC72FAD802D2847DCD9F992F3F55C241F65D44F1_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisTextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A_m88C9AF679301ABB958D4D24E822A33521E08FFD3 (Il2CppSharedGenericObject** ___0_source, TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A*, const RuntimeMethod*))TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisTextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A_m88C9AF679301ABB958D4D24E822A33521E08FFD3_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisTextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A_mAF37628D99B7AE42B9420533D24C7F5F7B94D986 (Il2CppSharedGenericObject* ___0_source, TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject*, TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A*, const RuntimeMethod*))TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisTextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A_mAF37628D99B7AE42B9420533D24C7F5F7B94D986_gshared)(___0_source, ___1_destination, method);
}
inline TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05 TypeConverter_2_Invoke_m5EFB8A4B526E5038BBEB12C50358AA67406DC302_inline (TypeConverter_2_tC0A832D8646E8260644D66DD7FA213AC57484831* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method)
{
	return ((  TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05 (*) (TypeConverter_2_tC0A832D8646E8260644D66DD7FA213AC57484831*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConverter_2_Invoke_m5EFB8A4B526E5038BBEB12C50358AA67406DC302_gshared_inline)(__this, ___0_value, method);
}
inline bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisTextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05_m8E83833ECA82E697F7024DC7070AC6128A018B76 (Il2CppSharedGenericObject** ___0_source, TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05*, const RuntimeMethod*))PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisTextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05_m8E83833ECA82E697F7024DC7070AC6128A018B76_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisTextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05_m7EADBF9FD32CFE1F86F36BAF4839C307E7B54042 (Il2CppSharedGenericObject** ___0_source, TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05*, const RuntimeMethod*))TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisTextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05_m7EADBF9FD32CFE1F86F36BAF4839C307E7B54042_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisTextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05_m77C51931C4EDB1902C16349B4C4D9BC785E6DEC0 (Il2CppSharedGenericObject** ___0_source, TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05*, const RuntimeMethod*))TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisTextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05_m77C51931C4EDB1902C16349B4C4D9BC785E6DEC0_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisTextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05_m05759354955D3A449C3EB327B9D0FC2995D78A16 (Il2CppSharedGenericObject* ___0_source, TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject*, TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05*, const RuntimeMethod*))TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisTextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05_m05759354955D3A449C3EB327B9D0FC2995D78A16_gshared)(___0_source, ___1_destination, method);
}
inline TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A TypeConverter_2_Invoke_m8A30F6853F5EE6FCFDE935B43D200CCAA09136B4_inline (TypeConverter_2_t0A5CBF00DFB82526AEB7B2DFEF71CA4F4807581E* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method)
{
	return ((  TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A (*) (TypeConverter_2_t0A5CBF00DFB82526AEB7B2DFEF71CA4F4807581E*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConverter_2_Invoke_m8A30F6853F5EE6FCFDE935B43D200CCAA09136B4_gshared_inline)(__this, ___0_value, method);
}
inline bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisTimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_mABD8E4CDEF3C53E49935B66E044F8D4A232A3D03 (Il2CppSharedGenericObject** ___0_source, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A*, const RuntimeMethod*))PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisTimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_mABD8E4CDEF3C53E49935B66E044F8D4A232A3D03_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisTimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_m069CFAFE812619C0986B6D70996F30B2A4F8B9BC (Il2CppSharedGenericObject** ___0_source, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A*, const RuntimeMethod*))TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisTimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_m069CFAFE812619C0986B6D70996F30B2A4F8B9BC_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisTimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_mA65027452747D38D73A877E1C21175A015F9177A (Il2CppSharedGenericObject** ___0_source, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A*, const RuntimeMethod*))TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisTimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_mA65027452747D38D73A877E1C21175A015F9177A_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisTimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_mCE6A94094E0147E3D6D83D9EED5C942FA998BBFC (Il2CppSharedGenericObject* ___0_source, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject*, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A*, const RuntimeMethod*))TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisTimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_mCE6A94094E0147E3D6D83D9EED5C942FA998BBFC_gshared)(___0_source, ___1_destination, method);
}
inline TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E TypeConverter_2_Invoke_mDFB5642B7FB6B4442DBC14B2F31EF44601F04D38_inline (TypeConverter_2_tBA10E08FB2B7207E85EAB1039CE76A8D80224B20* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method)
{
	return ((  TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E (*) (TypeConverter_2_tBA10E08FB2B7207E85EAB1039CE76A8D80224B20*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConverter_2_Invoke_mDFB5642B7FB6B4442DBC14B2F31EF44601F04D38_gshared_inline)(__this, ___0_value, method);
}
inline bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisTimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E_m1B1B4E79A79CB4606C4FCD10011C3C1E9C491B4F (Il2CppSharedGenericObject** ___0_source, TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E*, const RuntimeMethod*))PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisTimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E_m1B1B4E79A79CB4606C4FCD10011C3C1E9C491B4F_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisTimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E_mDC3DBAD282E45562925459BB094157FE8D7A39B1 (Il2CppSharedGenericObject** ___0_source, TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E*, const RuntimeMethod*))TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisTimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E_mDC3DBAD282E45562925459BB094157FE8D7A39B1_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisTimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E_m5050A815DCF77923C0D3454F0E2464A0CC9C2D12 (Il2CppSharedGenericObject** ___0_source, TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E*, const RuntimeMethod*))TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisTimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E_m5050A815DCF77923C0D3454F0E2464A0CC9C2D12_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisTimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E_m890F9B74999D7F62E686CB9028C19252CF5B3162 (Il2CppSharedGenericObject* ___0_source, TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject*, TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E*, const RuntimeMethod*))TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisTimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E_m890F9B74999D7F62E686CB9028C19252CF5B3162_gshared)(___0_source, ___1_destination, method);
}
inline TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502 TypeConverter_2_Invoke_mCE58430324F9B994275CA0432152E6690C870493_inline (TypeConverter_2_t26D60543337DCCA819FD538D85F40D86762DB0F2* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method)
{
	return ((  TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502 (*) (TypeConverter_2_t26D60543337DCCA819FD538D85F40D86762DB0F2*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConverter_2_Invoke_mCE58430324F9B994275CA0432152E6690C870493_gshared_inline)(__this, ___0_value, method);
}
inline bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisTransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502_m86DA4A09ED739EC95D08078C2A68B5D3B2331B4D (Il2CppSharedGenericObject** ___0_source, TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502*, const RuntimeMethod*))PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisTransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502_m86DA4A09ED739EC95D08078C2A68B5D3B2331B4D_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisTransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502_m43E97D6A9927E5D80F447A939DECC30242168E99 (Il2CppSharedGenericObject** ___0_source, TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502*, const RuntimeMethod*))TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisTransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502_m43E97D6A9927E5D80F447A939DECC30242168E99_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisTransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502_mC73284DDA65769315166572B6F9EBBB09FD66BAC (Il2CppSharedGenericObject** ___0_source, TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502*, const RuntimeMethod*))TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisTransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502_mC73284DDA65769315166572B6F9EBBB09FD66BAC_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisTransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502_mF9CB9E3DF63B70278C7644C14E87765DFF86202E (Il2CppSharedGenericObject* ___0_source, TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject*, TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502*, const RuntimeMethod*))TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisTransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502_mF9CB9E3DF63B70278C7644C14E87765DFF86202E_gshared)(___0_source, ___1_destination, method);
}
inline Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E TypeConverter_2_Invoke_mD793CD9960E098A5D8B04701404212678B3C4087_inline (TypeConverter_2_tC8DC9C48FBE571CF2E75D0324F34468EACBEB008* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method)
{
	return ((  Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E (*) (TypeConverter_2_tC8DC9C48FBE571CF2E75D0324F34468EACBEB008*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConverter_2_Invoke_mD793CD9960E098A5D8B04701404212678B3C4087_gshared_inline)(__this, ___0_value, method);
}
inline bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisTranslate_t494F6E802F8A640D67819C9D26BE62DED1218A8E_m59519C17558F8D8E4F1351404BEA83B969C19120 (Il2CppSharedGenericObject** ___0_source, Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E*, const RuntimeMethod*))PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisTranslate_t494F6E802F8A640D67819C9D26BE62DED1218A8E_m59519C17558F8D8E4F1351404BEA83B969C19120_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisTranslate_t494F6E802F8A640D67819C9D26BE62DED1218A8E_mE693B7D7A19E1DC6276F1A46097436590B6C96E4 (Il2CppSharedGenericObject** ___0_source, Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E*, const RuntimeMethod*))TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisTranslate_t494F6E802F8A640D67819C9D26BE62DED1218A8E_mE693B7D7A19E1DC6276F1A46097436590B6C96E4_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisTranslate_t494F6E802F8A640D67819C9D26BE62DED1218A8E_mF43635F25DDF8116F489001592D21F5AC5264A15 (Il2CppSharedGenericObject** ___0_source, Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E*, const RuntimeMethod*))TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisTranslate_t494F6E802F8A640D67819C9D26BE62DED1218A8E_mF43635F25DDF8116F489001592D21F5AC5264A15_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisTranslate_t494F6E802F8A640D67819C9D26BE62DED1218A8E_m15BCEE9792C8945FDE5437EC42A3AEC4C84FDC99 (Il2CppSharedGenericObject* ___0_source, Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject*, Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E*, const RuntimeMethod*))TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisTranslate_t494F6E802F8A640D67819C9D26BE62DED1218A8E_m15BCEE9792C8945FDE5437EC42A3AEC4C84FDC99_gshared)(___0_source, ___1_destination, method);
}
inline uint16_t TypeConverter_2_Invoke_m66222088B81B0479C4FAED81A6E115C2078D89A2_inline (TypeConverter_2_t7104BAD86AB01041A6B4CFA05DD8A0CF7B316EAE* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method)
{
	return ((  uint16_t (*) (TypeConverter_2_t7104BAD86AB01041A6B4CFA05DD8A0CF7B316EAE*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConverter_2_Invoke_m66222088B81B0479C4FAED81A6E115C2078D89A2_gshared_inline)(__this, ___0_value, method);
}
inline bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisUInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_mDA8A246BC062B5634F667D514235205969506D53 (Il2CppSharedGenericObject** ___0_source, uint16_t* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, uint16_t*, const RuntimeMethod*))PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisUInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_mDA8A246BC062B5634F667D514235205969506D53_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisUInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_m65E9FB7FA0D01A0CD52BDA1F0FD39CE635D5CF9B (Il2CppSharedGenericObject** ___0_source, uint16_t* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, uint16_t*, const RuntimeMethod*))TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisUInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_m65E9FB7FA0D01A0CD52BDA1F0FD39CE635D5CF9B_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisUInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_m7044D1087F56C3448C4455C14F31DD12DFA2A2FF (Il2CppSharedGenericObject** ___0_source, uint16_t* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, uint16_t*, const RuntimeMethod*))TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisUInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_m7044D1087F56C3448C4455C14F31DD12DFA2A2FF_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisUInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_m0CF638A658A95329981CFE92A200F9F026CC88BF (Il2CppSharedGenericObject* ___0_source, uint16_t* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject*, uint16_t*, const RuntimeMethod*))TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisUInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_m0CF638A658A95329981CFE92A200F9F026CC88BF_gshared)(___0_source, ___1_destination, method);
}
inline uint32_t TypeConverter_2_Invoke_mCBE8A03AC2A93E11AC276C8AB69B069E2DC24E9F_inline (TypeConverter_2_t987BA7DD2FE661C6A4CD1CE7F398720A1A912CDB* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method)
{
	return ((  uint32_t (*) (TypeConverter_2_t987BA7DD2FE661C6A4CD1CE7F398720A1A912CDB*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConverter_2_Invoke_mCBE8A03AC2A93E11AC276C8AB69B069E2DC24E9F_gshared_inline)(__this, ___0_value, method);
}
inline bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_mC57548E2FBB7801ADCA39608D4B49D6B97974514 (Il2CppSharedGenericObject** ___0_source, uint32_t* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, uint32_t*, const RuntimeMethod*))PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_mC57548E2FBB7801ADCA39608D4B49D6B97974514_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_m06E5488A389513768C081F56CFDE78AC028D9C43 (Il2CppSharedGenericObject** ___0_source, uint32_t* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, uint32_t*, const RuntimeMethod*))TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_m06E5488A389513768C081F56CFDE78AC028D9C43_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_m55BEAE3C511900D8ED0BA0D28D3F54CE3676D84C (Il2CppSharedGenericObject** ___0_source, uint32_t* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, uint32_t*, const RuntimeMethod*))TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_m55BEAE3C511900D8ED0BA0D28D3F54CE3676D84C_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_mC43EF7862142C0A1290BAC84D392D044737CAF02 (Il2CppSharedGenericObject* ___0_source, uint32_t* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject*, uint32_t*, const RuntimeMethod*))TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_mC43EF7862142C0A1290BAC84D392D044737CAF02_gshared)(___0_source, ___1_destination, method);
}
inline uint64_t TypeConverter_2_Invoke_mEA8D3ECFB70460557F24848D00C2A296D047A36F_inline (TypeConverter_2_tFE7942B61544B13EC61F654A379BB8C5C19E478F* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method)
{
	return ((  uint64_t (*) (TypeConverter_2_tFE7942B61544B13EC61F654A379BB8C5C19E478F*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConverter_2_Invoke_mEA8D3ECFB70460557F24848D00C2A296D047A36F_gshared_inline)(__this, ___0_value, method);
}
inline bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisUInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_mBB921111FF38E5C99FF61AE3BE80009C2E022239 (Il2CppSharedGenericObject** ___0_source, uint64_t* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, uint64_t*, const RuntimeMethod*))PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisUInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_mBB921111FF38E5C99FF61AE3BE80009C2E022239_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisUInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_m032089056E1895100A9FB554517491D88FD1A89A (Il2CppSharedGenericObject** ___0_source, uint64_t* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, uint64_t*, const RuntimeMethod*))TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisUInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_m032089056E1895100A9FB554517491D88FD1A89A_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisUInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_m6048AB2AE3D1B37759345D9381A4288919B5C3D6 (Il2CppSharedGenericObject** ___0_source, uint64_t* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, uint64_t*, const RuntimeMethod*))TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisUInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_m6048AB2AE3D1B37759345D9381A4288919B5C3D6_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisUInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_mB1C7ABF4F0D89B6AFF2CC47A8C61E42904145D05 (Il2CppSharedGenericObject* ___0_source, uint64_t* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject*, uint64_t*, const RuntimeMethod*))TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisUInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_mB1C7ABF4F0D89B6AFF2CC47A8C61E42904145D05_gshared)(___0_source, ___1_destination, method);
}
inline Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 TypeConverter_2_Invoke_m49AE9030B92C77BF35406171E80F83866E190EEB_inline (TypeConverter_2_t4C7D6F1114B9EFC390F0FE6F2860EDC1E7DF3049* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method)
{
	return ((  Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 (*) (TypeConverter_2_t4C7D6F1114B9EFC390F0FE6F2860EDC1E7DF3049*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConverter_2_Invoke_m49AE9030B92C77BF35406171E80F83866E190EEB_gshared_inline)(__this, ___0_value, method);
}
inline bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisVector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_m2CF3D0A8B3D448DC8DC9920EAB7DD7F7294385EF (Il2CppSharedGenericObject** ___0_source, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7*, const RuntimeMethod*))PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisVector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_m2CF3D0A8B3D448DC8DC9920EAB7DD7F7294385EF_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisVector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_mBC9E99471BC4B1516C14CA600EBF62C219CDE927 (Il2CppSharedGenericObject** ___0_source, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7*, const RuntimeMethod*))TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisVector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_mBC9E99471BC4B1516C14CA600EBF62C219CDE927_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisVector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_mF12E9E30A8C88ED1C3CDC1ABB42D399DB55766B5 (Il2CppSharedGenericObject** ___0_source, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7*, const RuntimeMethod*))TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisVector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_mF12E9E30A8C88ED1C3CDC1ABB42D399DB55766B5_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisVector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_mEAC9854D622F8E0FCDE60F2FD1E880F17E1D98BD (Il2CppSharedGenericObject* ___0_source, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject*, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7*, const RuntimeMethod*))TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisVector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_mEAC9854D622F8E0FCDE60F2FD1E880F17E1D98BD_gshared)(___0_source, ___1_destination, method);
}
inline Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 TypeConverter_2_Invoke_m9A7F8EB799C5DB7CC4A9461CF3A66B1A424F189D_inline (TypeConverter_2_tA9C93925BAFC7D4786356A2B45762EB2575F3986* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method)
{
	return ((  Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 (*) (TypeConverter_2_tA9C93925BAFC7D4786356A2B45762EB2575F3986*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConverter_2_Invoke_m9A7F8EB799C5DB7CC4A9461CF3A66B1A424F189D_gshared_inline)(__this, ___0_value, method);
}
inline bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisVector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_m49EFB846487E3484F55E93EA59F1C8680F01C2A3 (Il2CppSharedGenericObject** ___0_source, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*, const RuntimeMethod*))PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisVector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_m49EFB846487E3484F55E93EA59F1C8680F01C2A3_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisVector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_mA6528517794E3114FFAB96CC8420747CD0F9DCEF (Il2CppSharedGenericObject** ___0_source, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*, const RuntimeMethod*))TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisVector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_mA6528517794E3114FFAB96CC8420747CD0F9DCEF_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisVector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_m230B481A8A76B8DC7B7A99CDEEF2E6673CE432C8 (Il2CppSharedGenericObject** ___0_source, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*, const RuntimeMethod*))TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisVector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_m230B481A8A76B8DC7B7A99CDEEF2E6673CE432C8_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisVector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_m304562AB878726D52E63977FEBBF8A8E1784C510 (Il2CppSharedGenericObject* ___0_source, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject*, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*, const RuntimeMethod*))TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisVector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_m304562AB878726D52E63977FEBBF8A8E1784C510_gshared)(___0_source, ___1_destination, method);
}
inline Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 TypeConverter_2_Invoke_m88BD1040FEFBC4E99093EA05FF231808CAFDB905_inline (TypeConverter_2_t2257368AB189DB95AF22DD35774E8FEB55C630BB* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method)
{
	return ((  Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 (*) (TypeConverter_2_t2257368AB189DB95AF22DD35774E8FEB55C630BB*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConverter_2_Invoke_m88BD1040FEFBC4E99093EA05FF231808CAFDB905_gshared_inline)(__this, ___0_value, method);
}
inline bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m6157AA92D4D7AAB292C81468B7FFE47C97235CDD (Il2CppSharedGenericObject** ___0_source, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376*, const RuntimeMethod*))PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m6157AA92D4D7AAB292C81468B7FFE47C97235CDD_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_mCE9040441F7B72DA914C67E892AB79C88A378C16 (Il2CppSharedGenericObject** ___0_source, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376*, const RuntimeMethod*))TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_mCE9040441F7B72DA914C67E892AB79C88A378C16_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m2AF19A10CED2896DA749F3489173964612DDE1C1 (Il2CppSharedGenericObject** ___0_source, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376*, const RuntimeMethod*))TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m2AF19A10CED2896DA749F3489173964612DDE1C1_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m300E03EBD0D44EC7E31CEDAE2EDDBCD68477B15A (Il2CppSharedGenericObject* ___0_source, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject*, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376*, const RuntimeMethod*))TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m300E03EBD0D44EC7E31CEDAE2EDDBCD68477B15A_gshared)(___0_source, ___1_destination, method);
}
inline Il2CppSharedGenericObject* TypeConverter_2_Invoke_mF0FFFFF940DA8BB84CBB0B4BD67E875750ADA97C_inline (TypeConverter_2_t0525BA89BAB435F8C9F2EEF9023F9BCB7ABE80A1* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method)
{
	return ((  Il2CppSharedGenericObject* (*) (TypeConverter_2_t0525BA89BAB435F8C9F2EEF9023F9BCB7ABE80A1*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConverter_2_Invoke_mF0FFFFF940DA8BB84CBB0B4BD67E875750ADA97C_gshared_inline)(__this, ___0_value, method);
}
inline Il2CppSharedGenericObject** UnsafeUtility_As_TisIl2CppSharedGenericObject_TisIl2CppSharedGenericObject_m7E01BE5B3130A632C43D1F86A8781C30A93D3DCF_inline (Il2CppSharedGenericObject** ___0_from, const RuntimeMethod* method)
{
	return ((  Il2CppSharedGenericObject** (*) (Il2CppSharedGenericObject**, const RuntimeMethod*))UnsafeUtility_As_TisIl2CppSharedGenericObject_TisIl2CppSharedGenericObject_m7E01BE5B3130A632C43D1F86A8781C30A93D3DCF_gshared_inline)(___0_from, method);
}
inline bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisIl2CppSharedGenericObject_m8343A93DAE3091C3CD02BAC3040AB4BB095DB4ED (Il2CppSharedGenericObject** ___0_source, Il2CppSharedGenericObject** ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, Il2CppSharedGenericObject**, const RuntimeMethod*))PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisIl2CppSharedGenericObject_m8343A93DAE3091C3CD02BAC3040AB4BB095DB4ED_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisIl2CppSharedGenericObject_m034C149F56406F6438D59B3B56CE2DAD125E75D9 (Il2CppSharedGenericObject** ___0_source, Il2CppSharedGenericObject** ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisIl2CppSharedGenericObject_m034C149F56406F6438D59B3B56CE2DAD125E75D9_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisIl2CppSharedGenericObject_mDAB6678DE2D56B194CD5E28F0EE09524A56EB17C (Il2CppSharedGenericObject** ___0_source, Il2CppSharedGenericObject** ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisIl2CppSharedGenericObject_mDAB6678DE2D56B194CD5E28F0EE09524A56EB17C_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisIl2CppSharedGenericObject_m69CA52F1857A6F0CC726661F95B30610A2A5A056 (Il2CppSharedGenericObject* ___0_source, Il2CppSharedGenericObject** ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisIl2CppSharedGenericObject_m69CA52F1857A6F0CC726661F95B30610A2A5A056_gshared)(___0_source, ___1_destination, method);
}
inline int32_t TypeConverter_2_Invoke_m7765922B627FE0A4912228208A85C752498BDC44_inline (TypeConverter_2_t81D4A80534427AD7BC452191F15131144F2FF763* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method)
{
	return ((  int32_t (*) (TypeConverter_2_t81D4A80534427AD7BC452191F15131144F2FF763*, Il2CppSharedGenericObject**, const RuntimeMethod*))TypeConverter_2_Invoke_m7765922B627FE0A4912228208A85C752498BDC44_gshared_inline)(__this, ___0_value, method);
}
inline bool PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_m316683D4F266C24D4C1495CD004BDC50F3AE3827 (Il2CppSharedGenericObject** ___0_source, int32_t* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, int32_t*, const RuntimeMethod*))PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_m316683D4F266C24D4C1495CD004BDC50F3AE3827_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_m42DE9E0B9A4D56213CE7044948F570C5E27289F2 (Il2CppSharedGenericObject** ___0_source, int32_t* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, int32_t*, const RuntimeMethod*))TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_m42DE9E0B9A4D56213CE7044948F570C5E27289F2_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_mD67DFE8D393E6CC55EB59A3C824DD7F8FEBDA6C9 (Il2CppSharedGenericObject** ___0_source, int32_t* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject**, int32_t*, const RuntimeMethod*))TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_mD67DFE8D393E6CC55EB59A3C824DD7F8FEBDA6C9_gshared)(___0_source, ___1_destination, method);
}
inline bool TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_m0BDE3F76A27AF8EE49D883FDA385E6DC4AED439D (Il2CppSharedGenericObject* ___0_source, int32_t* ___1_destination, const RuntimeMethod* method)
{
	return ((  bool (*) (Il2CppSharedGenericObject*, int32_t*, const RuntimeMethod*))TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_m0BDE3F76A27AF8EE49D883FDA385E6DC4AED439D_gshared)(___0_source, ___1_destination, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F (Type_t* ___0_enumType, String_t* ___1_value, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_IsNumericType_m4ED38C1CEAEA27E582D274BA41FCEAA52D779936 (Type_t* ___0_t, const RuntimeMethod* method) ;
inline int32_t* UnsafeUtility_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_m9AEA7CA3ED58CAAF5CC970EF8B1182B9DC69D464_inline (bool* ___0_from, const RuntimeMethod* method)
{
	return ((  int32_t* (*) (bool*, const RuntimeMethod*))UnsafeUtility_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_m9AEA7CA3ED58CAAF5CC970EF8B1182B9DC69D464_gshared_inline)(___0_from, method);
}
inline Il2CppSharedGenericObject** UnsafeUtilityInternal_As_TisIl2CppSharedGenericObject_TisIl2CppSharedGenericObject_m1C63CD01558497B8FF90637D897964E5BF4FAC2A_inline (Il2CppSharedGenericObject** ___0_from, const RuntimeMethod* method)
{
	return ((  Il2CppSharedGenericObject** (*) (Il2CppSharedGenericObject**, const RuntimeMethod*))UnsafeUtilityInternal_As_TisIl2CppFullySharedGenericAny_TisIl2CppFullySharedGenericAny_mE1CA751887466B801BE69083C2B0EA3EDE41FF9B_fshared_inline)(___0_from, method);
}
inline int32_t* UnsafeUtilityInternal_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_mD2CFD786E18565D81928F220F62310DF589EEF5C_inline (bool* ___0_from, const RuntimeMethod* method)
{
	return ((  int32_t* (*) (bool*, const RuntimeMethod*))UnsafeUtilityInternal_As_TisIl2CppFullySharedGenericAny_TisIl2CppFullySharedGenericAny_mE1CA751887466B801BE69083C2B0EA3EDE41FF9B_fshared_inline)(___0_from, method);
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppSharedGenericObject_TisStyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471_mD35B586E2F5D62EFC7A9D6B4A389E057E5911E84_gshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppSharedGenericObject** ___1_source, StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471* ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471 V_1;
	memset((&V_1), 0, sizeof(V_1));
	TypeConverter_2_tF89582388D90E6733D9336D56E72113181F8C35B* V_2 = NULL;
	Il2CppSharedGenericObject* V_3 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_tF89582388D90E6733D9336D56E72113181F8C35B*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471* L_7 = ___2_destination;
		TypeConverter_2_tF89582388D90E6733D9336D56E72113181F8C35B* L_8 = V_2;
		Il2CppSharedGenericObject** L_9 = ___1_source;
		NullCheck(L_8);
		StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471 L_10;
		L_10 = TypeConverter_2_Invoke_mC00EB2E2FCBECD90D43B086E367A5588CFB7AF75_inline(L_8, L_9, NULL);
		*(StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471*)L_7 = L_10;
		Il2CppCodeGenWriteBarrier((void**)&((&(((StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471*)L_7)->___m_Value))->___m_Material), (void*)NULL);
		#if IL2CPP_ENABLE_STRICT_WRITE_BARRIERS
		Il2CppCodeGenWriteBarrier((void**)&((&(((StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471*)L_7)->___m_Value))->___propertyValues), (void*)NULL);
		#endif
		return (bool)1;
	}

IL_0034:
	{
		goto IL_0062;
	}

IL_0062:
	{
		Il2CppSharedGenericObject** L_11 = ___1_source;
		StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471* L_12 = ___2_destination;
		bool L_13;
		L_13 = PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471_m59DB4753957EB5BA30C48FE1C694E34BF7830C98(L_11, L_12, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_13)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppSharedGenericObject** L_14 = ___1_source;
		StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471* L_15 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_16;
		L_16 = TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471_mC96BA17CB5BF6E8B6AF14E6C0A26154D7811E722(L_14, L_15, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_16)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppSharedGenericObject** L_17 = ___1_source;
		StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471* L_18 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_19;
		L_19 = TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471_m5B1AD86BD6C6B2FC15C76AE6E8B16344BEFE7A3C(L_17, L_18, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_19)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppSharedGenericObject** L_20 = ___1_source;
		Il2CppSharedGenericObject* L_21 = (*(Il2CppSharedGenericObject**)L_20);
		StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471* L_22 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_23;
		L_23 = TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471_mC7A632F3E2D58B15813E5616DFC851B3410FBA31(L_21, L_22, il2cpp_rgctx_method(method->rgctx_data, 10));
		if (!L_23)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		goto IL_00be;
	}

IL_00be:
	{
		Il2CppSharedGenericObject** L_24 = ___1_source;
		Il2CppSharedGenericObject* L_25 = (*(Il2CppSharedGenericObject**)L_24);
		V_3 = L_25;
		Il2CppSharedGenericObject* L_26 = V_3;
		if (!((RuntimeObject*)IsInstSealed((RuntimeObject*)L_26, il2cpp_rgctx_data(method->rgctx_data, 3))))
		{
			goto IL_00ec;
		}
	}
	{
		Il2CppSharedGenericObject* L_27 = V_3;
		V_1 = ((*(StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471*)UnBox(((RuntimeObject*)IsInstSealed((RuntimeObject*)L_27, il2cpp_rgctx_data(method->rgctx_data, 3))), il2cpp_rgctx_data(method->rgctx_data, 3))));
		StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471* L_28 = ___2_destination;
		StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471 L_29 = V_1;
		*(StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471*)L_28 = L_29;
		Il2CppCodeGenWriteBarrier((void**)&((&(((StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471*)L_28)->___m_Value))->___m_Material), (void*)NULL);
		#if IL2CPP_ENABLE_STRICT_WRITE_BARRIERS
		Il2CppCodeGenWriteBarrier((void**)&((&(((StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471*)L_28)->___m_Value))->___propertyValues), (void*)NULL);
		#endif
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_32, NULL);
		NullCheck(L_31);
		bool L_34;
		L_34 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_31, L_33);
		if (!L_34)
		{
			goto IL_011f;
		}
	}
	{
		StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471* L_35 = ___2_destination;
		Il2CppSharedGenericObject** L_36 = ___1_source;
		Il2CppSharedGenericObject* L_37 = (*(Il2CppSharedGenericObject**)L_36);
		*(StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471*)L_35 = ((*(StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471*)UnBox((RuntimeObject*)L_37, il2cpp_rgctx_data(method->rgctx_data, 3))));
		Il2CppCodeGenWriteBarrier((void**)&((&(((StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471*)L_35)->___m_Value))->___m_Material), (void*)NULL);
		#if IL2CPP_ENABLE_STRICT_WRITE_BARRIERS
		Il2CppCodeGenWriteBarrier((void**)&((&(((StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471*)L_35)->___m_Value))->___propertyValues), (void*)NULL);
		#endif
		return (bool)1;
	}

IL_011f:
	{
		goto IL_0177;
	}

IL_0177:
	{
		goto IL_01aa;
	}

IL_01aa:
	{
		bool L_38 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_38)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_39 = ___1_source;
		Il2CppSharedGenericObject* L_40 = (*(Il2CppSharedGenericObject**)L_39);
		if (L_40)
		{
			goto IL_01db;
		}
	}
	{
		StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471* L_41 = ___2_destination;
		il2cpp_codegen_initobj(L_41, sizeof(StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471));
		return (bool)1;
	}

IL_01db:
	{
		StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471* L_42 = ___2_destination;
		il2cpp_codegen_initobj(L_42, sizeof(StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471));
		return (bool)0;
	}
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppSharedGenericObject_TisStylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF_mC4A3FEA9EC3BA6FF4BCD0A3983020D0269A98C7F_gshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppSharedGenericObject** ___1_source, StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF* ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF V_1;
	memset((&V_1), 0, sizeof(V_1));
	TypeConverter_2_t6639570A10ABBF2F824E8BC88925BA36914DC1C7* V_2 = NULL;
	Il2CppSharedGenericObject* V_3 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_t6639570A10ABBF2F824E8BC88925BA36914DC1C7*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF* L_7 = ___2_destination;
		TypeConverter_2_t6639570A10ABBF2F824E8BC88925BA36914DC1C7* L_8 = V_2;
		Il2CppSharedGenericObject** L_9 = ___1_source;
		NullCheck(L_8);
		StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF L_10;
		L_10 = TypeConverter_2_Invoke_m9364011AA418E118526924552C4365CDBE204F0C_inline(L_8, L_9, NULL);
		*(StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF*)L_7 = L_10;
		Il2CppCodeGenWriteBarrier((void**)&(((StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF*)L_7)->___U3CnameU3Ek__BackingField), (void*)NULL);
		return (bool)1;
	}

IL_0034:
	{
		goto IL_0062;
	}

IL_0062:
	{
		Il2CppSharedGenericObject** L_11 = ___1_source;
		StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF* L_12 = ___2_destination;
		bool L_13;
		L_13 = PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF_m78F73284BBAFADA319C7804E792D97C79B486CC2(L_11, L_12, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_13)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppSharedGenericObject** L_14 = ___1_source;
		StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF* L_15 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_16;
		L_16 = TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF_m8710A9FFE30405668A0F172E1A2972301613D0B4(L_14, L_15, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_16)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppSharedGenericObject** L_17 = ___1_source;
		StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF* L_18 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_19;
		L_19 = TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF_mE931009931A256BCE221B6717D0E9068571475C4(L_17, L_18, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_19)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppSharedGenericObject** L_20 = ___1_source;
		Il2CppSharedGenericObject* L_21 = (*(Il2CppSharedGenericObject**)L_20);
		StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF* L_22 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_23;
		L_23 = TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF_mE5C6E0BB516B4472F1806B58F71AAF258415E9D5(L_21, L_22, il2cpp_rgctx_method(method->rgctx_data, 10));
		if (!L_23)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		goto IL_00be;
	}

IL_00be:
	{
		Il2CppSharedGenericObject** L_24 = ___1_source;
		Il2CppSharedGenericObject* L_25 = (*(Il2CppSharedGenericObject**)L_24);
		V_3 = L_25;
		Il2CppSharedGenericObject* L_26 = V_3;
		if (!((RuntimeObject*)IsInstSealed((RuntimeObject*)L_26, il2cpp_rgctx_data(method->rgctx_data, 3))))
		{
			goto IL_00ec;
		}
	}
	{
		Il2CppSharedGenericObject* L_27 = V_3;
		V_1 = ((*(StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF*)UnBox(((RuntimeObject*)IsInstSealed((RuntimeObject*)L_27, il2cpp_rgctx_data(method->rgctx_data, 3))), il2cpp_rgctx_data(method->rgctx_data, 3))));
		StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF* L_28 = ___2_destination;
		StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF L_29 = V_1;
		*(StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF*)L_28 = L_29;
		Il2CppCodeGenWriteBarrier((void**)&(((StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF*)L_28)->___U3CnameU3Ek__BackingField), (void*)NULL);
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_32, NULL);
		NullCheck(L_31);
		bool L_34;
		L_34 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_31, L_33);
		if (!L_34)
		{
			goto IL_011f;
		}
	}
	{
		StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF* L_35 = ___2_destination;
		Il2CppSharedGenericObject** L_36 = ___1_source;
		Il2CppSharedGenericObject* L_37 = (*(Il2CppSharedGenericObject**)L_36);
		*(StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF*)L_35 = ((*(StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF*)UnBox((RuntimeObject*)L_37, il2cpp_rgctx_data(method->rgctx_data, 3))));
		Il2CppCodeGenWriteBarrier((void**)&(((StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF*)L_35)->___U3CnameU3Ek__BackingField), (void*)NULL);
		return (bool)1;
	}

IL_011f:
	{
		goto IL_0177;
	}

IL_0177:
	{
		goto IL_01aa;
	}

IL_01aa:
	{
		bool L_38 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_38)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_39 = ___1_source;
		Il2CppSharedGenericObject* L_40 = (*(Il2CppSharedGenericObject**)L_39);
		if (L_40)
		{
			goto IL_01db;
		}
	}
	{
		StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF* L_41 = ___2_destination;
		il2cpp_codegen_initobj(L_41, sizeof(StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF));
		return (bool)1;
	}

IL_01db:
	{
		StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF* L_42 = ___2_destination;
		il2cpp_codegen_initobj(L_42, sizeof(StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF));
		return (bool)0;
	}
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppSharedGenericObject_TisStyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906_mA47C8EE22D7157C19E1F80C891631336118A5012_gshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppSharedGenericObject** ___1_source, StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906* ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906 V_1;
	memset((&V_1), 0, sizeof(V_1));
	TypeConverter_2_t14B52AF1258A5A9C9C7C40B585BCC796EB89546E* V_2 = NULL;
	Il2CppSharedGenericObject* V_3 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_t14B52AF1258A5A9C9C7C40B585BCC796EB89546E*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906* L_7 = ___2_destination;
		TypeConverter_2_t14B52AF1258A5A9C9C7C40B585BCC796EB89546E* L_8 = V_2;
		Il2CppSharedGenericObject** L_9 = ___1_source;
		NullCheck(L_8);
		StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906 L_10;
		L_10 = TypeConverter_2_Invoke_m8BAF3CB8DC77C7156495925FCEB4DD4EBD2A166D_inline(L_8, L_9, NULL);
		*(StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906*)L_7 = L_10;
		return (bool)1;
	}

IL_0034:
	{
		goto IL_0062;
	}

IL_0062:
	{
		Il2CppSharedGenericObject** L_11 = ___1_source;
		StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906* L_12 = ___2_destination;
		bool L_13;
		L_13 = PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906_mF340730BADE7CD1655772A73E270A945D0892216(L_11, L_12, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_13)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppSharedGenericObject** L_14 = ___1_source;
		StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906* L_15 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_16;
		L_16 = TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906_m5C9EC8D76409E9B6B1CA0A23CA75F89E39E2F80D(L_14, L_15, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_16)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppSharedGenericObject** L_17 = ___1_source;
		StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906* L_18 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_19;
		L_19 = TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906_mCBE71A84055551D9FF60862B884C28F1E9782E83(L_17, L_18, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_19)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppSharedGenericObject** L_20 = ___1_source;
		Il2CppSharedGenericObject* L_21 = (*(Il2CppSharedGenericObject**)L_20);
		StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906* L_22 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_23;
		L_23 = TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906_mE081F767B5982BA86FA384B5F73E377754FEA1ED(L_21, L_22, il2cpp_rgctx_method(method->rgctx_data, 10));
		if (!L_23)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		goto IL_00be;
	}

IL_00be:
	{
		Il2CppSharedGenericObject** L_24 = ___1_source;
		Il2CppSharedGenericObject* L_25 = (*(Il2CppSharedGenericObject**)L_24);
		V_3 = L_25;
		Il2CppSharedGenericObject* L_26 = V_3;
		if (!((RuntimeObject*)IsInstSealed((RuntimeObject*)L_26, il2cpp_rgctx_data(method->rgctx_data, 3))))
		{
			goto IL_00ec;
		}
	}
	{
		Il2CppSharedGenericObject* L_27 = V_3;
		V_1 = ((*(StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906*)UnBox(((RuntimeObject*)IsInstSealed((RuntimeObject*)L_27, il2cpp_rgctx_data(method->rgctx_data, 3))), il2cpp_rgctx_data(method->rgctx_data, 3))));
		StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906* L_28 = ___2_destination;
		StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906 L_29 = V_1;
		*(StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906*)L_28 = L_29;
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_32, NULL);
		NullCheck(L_31);
		bool L_34;
		L_34 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_31, L_33);
		if (!L_34)
		{
			goto IL_011f;
		}
	}
	{
		StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906* L_35 = ___2_destination;
		Il2CppSharedGenericObject** L_36 = ___1_source;
		Il2CppSharedGenericObject* L_37 = (*(Il2CppSharedGenericObject**)L_36);
		*(StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906*)L_35 = ((*(StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906*)UnBox((RuntimeObject*)L_37, il2cpp_rgctx_data(method->rgctx_data, 3))));
		return (bool)1;
	}

IL_011f:
	{
		goto IL_0177;
	}

IL_0177:
	{
		goto IL_01aa;
	}

IL_01aa:
	{
		bool L_38 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_38)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_39 = ___1_source;
		Il2CppSharedGenericObject* L_40 = (*(Il2CppSharedGenericObject**)L_39);
		if (L_40)
		{
			goto IL_01db;
		}
	}
	{
		StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906* L_41 = ___2_destination;
		il2cpp_codegen_initobj(L_41, sizeof(StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906));
		return (bool)1;
	}

IL_01db:
	{
		StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906* L_42 = ___2_destination;
		il2cpp_codegen_initobj(L_42, sizeof(StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906));
		return (bool)0;
	}
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppSharedGenericObject_TisStyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B_m8D640B696C77F9D30498639D52EEDAB88779CE5A_gshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppSharedGenericObject** ___1_source, StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B* ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B V_1;
	memset((&V_1), 0, sizeof(V_1));
	TypeConverter_2_t0D424B5552ED05121DAA8FBC96BFA5B5D7C25841* V_2 = NULL;
	Il2CppSharedGenericObject* V_3 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_t0D424B5552ED05121DAA8FBC96BFA5B5D7C25841*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B* L_7 = ___2_destination;
		TypeConverter_2_t0D424B5552ED05121DAA8FBC96BFA5B5D7C25841* L_8 = V_2;
		Il2CppSharedGenericObject** L_9 = ___1_source;
		NullCheck(L_8);
		StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B L_10;
		L_10 = TypeConverter_2_Invoke_m2E33325E79FFF74B5F0696488BE57DC3D7DCB412_inline(L_8, L_9, NULL);
		*(StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B*)L_7 = L_10;
		return (bool)1;
	}

IL_0034:
	{
		goto IL_0062;
	}

IL_0062:
	{
		Il2CppSharedGenericObject** L_11 = ___1_source;
		StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B* L_12 = ___2_destination;
		bool L_13;
		L_13 = PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B_mEDFD14C52E172CCF4A61A04A9A094E9D6F7DB156(L_11, L_12, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_13)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppSharedGenericObject** L_14 = ___1_source;
		StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B* L_15 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_16;
		L_16 = TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B_mEF1C101D1CB9BAAD6F887252CEEAB935DD02443F(L_14, L_15, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_16)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppSharedGenericObject** L_17 = ___1_source;
		StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B* L_18 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_19;
		L_19 = TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B_mA47EF357DF4978A62F798ABD17920EA9EF28A241(L_17, L_18, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_19)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppSharedGenericObject** L_20 = ___1_source;
		Il2CppSharedGenericObject* L_21 = (*(Il2CppSharedGenericObject**)L_20);
		StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B* L_22 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_23;
		L_23 = TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B_m7BF85D612CF7C2D1E96964A290DBFD9D384AF493(L_21, L_22, il2cpp_rgctx_method(method->rgctx_data, 10));
		if (!L_23)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		goto IL_00be;
	}

IL_00be:
	{
		Il2CppSharedGenericObject** L_24 = ___1_source;
		Il2CppSharedGenericObject* L_25 = (*(Il2CppSharedGenericObject**)L_24);
		V_3 = L_25;
		Il2CppSharedGenericObject* L_26 = V_3;
		if (!((RuntimeObject*)IsInstSealed((RuntimeObject*)L_26, il2cpp_rgctx_data(method->rgctx_data, 3))))
		{
			goto IL_00ec;
		}
	}
	{
		Il2CppSharedGenericObject* L_27 = V_3;
		V_1 = ((*(StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B*)UnBox(((RuntimeObject*)IsInstSealed((RuntimeObject*)L_27, il2cpp_rgctx_data(method->rgctx_data, 3))), il2cpp_rgctx_data(method->rgctx_data, 3))));
		StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B* L_28 = ___2_destination;
		StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B L_29 = V_1;
		*(StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B*)L_28 = L_29;
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_32, NULL);
		NullCheck(L_31);
		bool L_34;
		L_34 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_31, L_33);
		if (!L_34)
		{
			goto IL_011f;
		}
	}
	{
		StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B* L_35 = ___2_destination;
		Il2CppSharedGenericObject** L_36 = ___1_source;
		Il2CppSharedGenericObject* L_37 = (*(Il2CppSharedGenericObject**)L_36);
		*(StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B*)L_35 = ((*(StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B*)UnBox((RuntimeObject*)L_37, il2cpp_rgctx_data(method->rgctx_data, 3))));
		return (bool)1;
	}

IL_011f:
	{
		goto IL_0177;
	}

IL_0177:
	{
		goto IL_01aa;
	}

IL_01aa:
	{
		bool L_38 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_38)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_39 = ___1_source;
		Il2CppSharedGenericObject* L_40 = (*(Il2CppSharedGenericObject**)L_39);
		if (L_40)
		{
			goto IL_01db;
		}
	}
	{
		StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B* L_41 = ___2_destination;
		il2cpp_codegen_initobj(L_41, sizeof(StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B));
		return (bool)1;
	}

IL_01db:
	{
		StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B* L_42 = ___2_destination;
		il2cpp_codegen_initobj(L_42, sizeof(StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B));
		return (bool)0;
	}
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppSharedGenericObject_TisStyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC_mE09E8E255E1C722A5876B74374DB1D5533F8C378_gshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppSharedGenericObject** ___1_source, StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC* ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC V_1;
	memset((&V_1), 0, sizeof(V_1));
	TypeConverter_2_t325870E3CF7DE93A02F5E359A73B09EE687F7764* V_2 = NULL;
	Il2CppSharedGenericObject* V_3 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_t325870E3CF7DE93A02F5E359A73B09EE687F7764*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC* L_7 = ___2_destination;
		TypeConverter_2_t325870E3CF7DE93A02F5E359A73B09EE687F7764* L_8 = V_2;
		Il2CppSharedGenericObject** L_9 = ___1_source;
		NullCheck(L_8);
		StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC L_10;
		L_10 = TypeConverter_2_Invoke_m301828B6620219C395E629511178814425BBA544_inline(L_8, L_9, NULL);
		*(StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC*)L_7 = L_10;
		return (bool)1;
	}

IL_0034:
	{
		goto IL_0062;
	}

IL_0062:
	{
		Il2CppSharedGenericObject** L_11 = ___1_source;
		StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC* L_12 = ___2_destination;
		bool L_13;
		L_13 = PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC_m61EB4AA6047F4BF2A299412C79F0BAE64EF8577C(L_11, L_12, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_13)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppSharedGenericObject** L_14 = ___1_source;
		StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC* L_15 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_16;
		L_16 = TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC_m5221BCC9C76B1529CD3967FF3F7037B38BA59665(L_14, L_15, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_16)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppSharedGenericObject** L_17 = ___1_source;
		StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC* L_18 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_19;
		L_19 = TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC_mE3243DEF7BCF96634BF3897EDE812C72D36C226E(L_17, L_18, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_19)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppSharedGenericObject** L_20 = ___1_source;
		Il2CppSharedGenericObject* L_21 = (*(Il2CppSharedGenericObject**)L_20);
		StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC* L_22 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_23;
		L_23 = TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC_m0A77200F22765DC6ED2ED451CC005E908F06A11C(L_21, L_22, il2cpp_rgctx_method(method->rgctx_data, 10));
		if (!L_23)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		goto IL_00be;
	}

IL_00be:
	{
		Il2CppSharedGenericObject** L_24 = ___1_source;
		Il2CppSharedGenericObject* L_25 = (*(Il2CppSharedGenericObject**)L_24);
		V_3 = L_25;
		Il2CppSharedGenericObject* L_26 = V_3;
		if (!((RuntimeObject*)IsInstSealed((RuntimeObject*)L_26, il2cpp_rgctx_data(method->rgctx_data, 3))))
		{
			goto IL_00ec;
		}
	}
	{
		Il2CppSharedGenericObject* L_27 = V_3;
		V_1 = ((*(StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC*)UnBox(((RuntimeObject*)IsInstSealed((RuntimeObject*)L_27, il2cpp_rgctx_data(method->rgctx_data, 3))), il2cpp_rgctx_data(method->rgctx_data, 3))));
		StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC* L_28 = ___2_destination;
		StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC L_29 = V_1;
		*(StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC*)L_28 = L_29;
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_32, NULL);
		NullCheck(L_31);
		bool L_34;
		L_34 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_31, L_33);
		if (!L_34)
		{
			goto IL_011f;
		}
	}
	{
		StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC* L_35 = ___2_destination;
		Il2CppSharedGenericObject** L_36 = ___1_source;
		Il2CppSharedGenericObject* L_37 = (*(Il2CppSharedGenericObject**)L_36);
		*(StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC*)L_35 = ((*(StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC*)UnBox((RuntimeObject*)L_37, il2cpp_rgctx_data(method->rgctx_data, 3))));
		return (bool)1;
	}

IL_011f:
	{
		goto IL_0177;
	}

IL_0177:
	{
		goto IL_01aa;
	}

IL_01aa:
	{
		bool L_38 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_38)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_39 = ___1_source;
		Il2CppSharedGenericObject* L_40 = (*(Il2CppSharedGenericObject**)L_39);
		if (L_40)
		{
			goto IL_01db;
		}
	}
	{
		StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC* L_41 = ___2_destination;
		il2cpp_codegen_initobj(L_41, sizeof(StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC));
		return (bool)1;
	}

IL_01db:
	{
		StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC* L_42 = ___2_destination;
		il2cpp_codegen_initobj(L_42, sizeof(StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC));
		return (bool)0;
	}
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppSharedGenericObject_TisStyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A_m3690DBF6F7EA004BFFA80FFE179926C949ECDD37_gshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppSharedGenericObject** ___1_source, StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A* ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A V_1;
	memset((&V_1), 0, sizeof(V_1));
	TypeConverter_2_t77EBC7DE8779DBFC8C888CCCBA1C57A1900F8D0E* V_2 = NULL;
	Il2CppSharedGenericObject* V_3 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_t77EBC7DE8779DBFC8C888CCCBA1C57A1900F8D0E*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A* L_7 = ___2_destination;
		TypeConverter_2_t77EBC7DE8779DBFC8C888CCCBA1C57A1900F8D0E* L_8 = V_2;
		Il2CppSharedGenericObject** L_9 = ___1_source;
		NullCheck(L_8);
		StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A L_10;
		L_10 = TypeConverter_2_Invoke_mDE9C8CB32A3B1147B5AFF244AB7647F2EE4C310E_inline(L_8, L_9, NULL);
		*(StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A*)L_7 = L_10;
		return (bool)1;
	}

IL_0034:
	{
		goto IL_0062;
	}

IL_0062:
	{
		Il2CppSharedGenericObject** L_11 = ___1_source;
		StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A* L_12 = ___2_destination;
		bool L_13;
		L_13 = PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A_m03CDF717FFC10FA57D8FCB8AEF6475A0FDFC73FC(L_11, L_12, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_13)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppSharedGenericObject** L_14 = ___1_source;
		StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A* L_15 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_16;
		L_16 = TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A_mFB30EDCEA7A892A3E41BF1CC21A9A18510955E88(L_14, L_15, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_16)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppSharedGenericObject** L_17 = ___1_source;
		StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A* L_18 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_19;
		L_19 = TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A_m19E6B111B2D7BC7EE7CF6553C46525BB51F4120F(L_17, L_18, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_19)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppSharedGenericObject** L_20 = ___1_source;
		Il2CppSharedGenericObject* L_21 = (*(Il2CppSharedGenericObject**)L_20);
		StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A* L_22 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_23;
		L_23 = TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A_m853A450EC24CDBC2E14281CE2C04239CF7E7FA60(L_21, L_22, il2cpp_rgctx_method(method->rgctx_data, 10));
		if (!L_23)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		goto IL_00be;
	}

IL_00be:
	{
		Il2CppSharedGenericObject** L_24 = ___1_source;
		Il2CppSharedGenericObject* L_25 = (*(Il2CppSharedGenericObject**)L_24);
		V_3 = L_25;
		Il2CppSharedGenericObject* L_26 = V_3;
		if (!((RuntimeObject*)IsInstSealed((RuntimeObject*)L_26, il2cpp_rgctx_data(method->rgctx_data, 3))))
		{
			goto IL_00ec;
		}
	}
	{
		Il2CppSharedGenericObject* L_27 = V_3;
		V_1 = ((*(StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A*)UnBox(((RuntimeObject*)IsInstSealed((RuntimeObject*)L_27, il2cpp_rgctx_data(method->rgctx_data, 3))), il2cpp_rgctx_data(method->rgctx_data, 3))));
		StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A* L_28 = ___2_destination;
		StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A L_29 = V_1;
		*(StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A*)L_28 = L_29;
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_32, NULL);
		NullCheck(L_31);
		bool L_34;
		L_34 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_31, L_33);
		if (!L_34)
		{
			goto IL_011f;
		}
	}
	{
		StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A* L_35 = ___2_destination;
		Il2CppSharedGenericObject** L_36 = ___1_source;
		Il2CppSharedGenericObject* L_37 = (*(Il2CppSharedGenericObject**)L_36);
		*(StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A*)L_35 = ((*(StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A*)UnBox((RuntimeObject*)L_37, il2cpp_rgctx_data(method->rgctx_data, 3))));
		return (bool)1;
	}

IL_011f:
	{
		goto IL_0177;
	}

IL_0177:
	{
		goto IL_01aa;
	}

IL_01aa:
	{
		bool L_38 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_38)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_39 = ___1_source;
		Il2CppSharedGenericObject* L_40 = (*(Il2CppSharedGenericObject**)L_39);
		if (L_40)
		{
			goto IL_01db;
		}
	}
	{
		StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A* L_41 = ___2_destination;
		il2cpp_codegen_initobj(L_41, sizeof(StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A));
		return (bool)1;
	}

IL_01db:
	{
		StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A* L_42 = ___2_destination;
		il2cpp_codegen_initobj(L_42, sizeof(StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A));
		return (bool)0;
	}
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppSharedGenericObject_TisStyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252_m053907FF0AB5513579198DD4CC754CD696D911F7_gshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppSharedGenericObject** ___1_source, StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252* ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252 V_1;
	memset((&V_1), 0, sizeof(V_1));
	TypeConverter_2_t2590D829276A4C224936EDAFCF1D1137DC63F062* V_2 = NULL;
	Il2CppSharedGenericObject* V_3 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_t2590D829276A4C224936EDAFCF1D1137DC63F062*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252* L_7 = ___2_destination;
		TypeConverter_2_t2590D829276A4C224936EDAFCF1D1137DC63F062* L_8 = V_2;
		Il2CppSharedGenericObject** L_9 = ___1_source;
		NullCheck(L_8);
		StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252 L_10;
		L_10 = TypeConverter_2_Invoke_mBE4E53C83E451210FA4A9D332098E0DBD397DDFA_inline(L_8, L_9, NULL);
		*(StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252*)L_7 = L_10;
		return (bool)1;
	}

IL_0034:
	{
		goto IL_0062;
	}

IL_0062:
	{
		Il2CppSharedGenericObject** L_11 = ___1_source;
		StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252* L_12 = ___2_destination;
		bool L_13;
		L_13 = PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252_m36A599F60624F70FD50DCB07B16B9BA5BD7F6A98(L_11, L_12, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_13)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppSharedGenericObject** L_14 = ___1_source;
		StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252* L_15 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_16;
		L_16 = TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252_m9359627757B7AA5BAEABF2E3733CA75250B71689(L_14, L_15, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_16)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppSharedGenericObject** L_17 = ___1_source;
		StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252* L_18 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_19;
		L_19 = TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252_m92F5D0FB29637BCC654F196DB59AE83AB1503B37(L_17, L_18, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_19)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppSharedGenericObject** L_20 = ___1_source;
		Il2CppSharedGenericObject* L_21 = (*(Il2CppSharedGenericObject**)L_20);
		StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252* L_22 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_23;
		L_23 = TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252_mEE7F4A8F63991814B174D57FCF6FC2F496DF7EA5(L_21, L_22, il2cpp_rgctx_method(method->rgctx_data, 10));
		if (!L_23)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		goto IL_00be;
	}

IL_00be:
	{
		Il2CppSharedGenericObject** L_24 = ___1_source;
		Il2CppSharedGenericObject* L_25 = (*(Il2CppSharedGenericObject**)L_24);
		V_3 = L_25;
		Il2CppSharedGenericObject* L_26 = V_3;
		if (!((RuntimeObject*)IsInstSealed((RuntimeObject*)L_26, il2cpp_rgctx_data(method->rgctx_data, 3))))
		{
			goto IL_00ec;
		}
	}
	{
		Il2CppSharedGenericObject* L_27 = V_3;
		V_1 = ((*(StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252*)UnBox(((RuntimeObject*)IsInstSealed((RuntimeObject*)L_27, il2cpp_rgctx_data(method->rgctx_data, 3))), il2cpp_rgctx_data(method->rgctx_data, 3))));
		StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252* L_28 = ___2_destination;
		StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252 L_29 = V_1;
		*(StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252*)L_28 = L_29;
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_32, NULL);
		NullCheck(L_31);
		bool L_34;
		L_34 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_31, L_33);
		if (!L_34)
		{
			goto IL_011f;
		}
	}
	{
		StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252* L_35 = ___2_destination;
		Il2CppSharedGenericObject** L_36 = ___1_source;
		Il2CppSharedGenericObject* L_37 = (*(Il2CppSharedGenericObject**)L_36);
		*(StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252*)L_35 = ((*(StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252*)UnBox((RuntimeObject*)L_37, il2cpp_rgctx_data(method->rgctx_data, 3))));
		return (bool)1;
	}

IL_011f:
	{
		goto IL_0177;
	}

IL_0177:
	{
		goto IL_01aa;
	}

IL_01aa:
	{
		bool L_38 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_38)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_39 = ___1_source;
		Il2CppSharedGenericObject* L_40 = (*(Il2CppSharedGenericObject**)L_39);
		if (L_40)
		{
			goto IL_01db;
		}
	}
	{
		StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252* L_41 = ___2_destination;
		il2cpp_codegen_initobj(L_41, sizeof(StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252));
		return (bool)1;
	}

IL_01db:
	{
		StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252* L_42 = ___2_destination;
		il2cpp_codegen_initobj(L_42, sizeof(StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252));
		return (bool)0;
	}
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppSharedGenericObject_TisStyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6_mE626EEC193F9D19796E0CF63700C2812FD5C0A02_gshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppSharedGenericObject** ___1_source, StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6* ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6 V_1;
	memset((&V_1), 0, sizeof(V_1));
	TypeConverter_2_t3B4B4ED61AFE2B4C7E58725FA7AE976658EDFC5F* V_2 = NULL;
	Il2CppSharedGenericObject* V_3 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_t3B4B4ED61AFE2B4C7E58725FA7AE976658EDFC5F*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6* L_7 = ___2_destination;
		TypeConverter_2_t3B4B4ED61AFE2B4C7E58725FA7AE976658EDFC5F* L_8 = V_2;
		Il2CppSharedGenericObject** L_9 = ___1_source;
		NullCheck(L_8);
		StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6 L_10;
		L_10 = TypeConverter_2_Invoke_mB032B3ECE8561B150D6ACFC6C00837DB7C97AD25_inline(L_8, L_9, NULL);
		*(StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6*)L_7 = L_10;
		return (bool)1;
	}

IL_0034:
	{
		goto IL_0062;
	}

IL_0062:
	{
		Il2CppSharedGenericObject** L_11 = ___1_source;
		StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6* L_12 = ___2_destination;
		bool L_13;
		L_13 = PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6_mC70333DA7CA3AFF76D3E9574EE81479CE9BC2840(L_11, L_12, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_13)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppSharedGenericObject** L_14 = ___1_source;
		StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6* L_15 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_16;
		L_16 = TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6_m59AB4830924D3EB4EF592D33AF615CDB18F04D17(L_14, L_15, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_16)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppSharedGenericObject** L_17 = ___1_source;
		StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6* L_18 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_19;
		L_19 = TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6_mC010D90CA83E3F0856A54E04B37DCF13940AB474(L_17, L_18, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_19)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppSharedGenericObject** L_20 = ___1_source;
		Il2CppSharedGenericObject* L_21 = (*(Il2CppSharedGenericObject**)L_20);
		StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6* L_22 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_23;
		L_23 = TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6_m8399BB721318A07B2CB98B770031EFC5EF12E7F7(L_21, L_22, il2cpp_rgctx_method(method->rgctx_data, 10));
		if (!L_23)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		goto IL_00be;
	}

IL_00be:
	{
		Il2CppSharedGenericObject** L_24 = ___1_source;
		Il2CppSharedGenericObject* L_25 = (*(Il2CppSharedGenericObject**)L_24);
		V_3 = L_25;
		Il2CppSharedGenericObject* L_26 = V_3;
		if (!((RuntimeObject*)IsInstSealed((RuntimeObject*)L_26, il2cpp_rgctx_data(method->rgctx_data, 3))))
		{
			goto IL_00ec;
		}
	}
	{
		Il2CppSharedGenericObject* L_27 = V_3;
		V_1 = ((*(StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6*)UnBox(((RuntimeObject*)IsInstSealed((RuntimeObject*)L_27, il2cpp_rgctx_data(method->rgctx_data, 3))), il2cpp_rgctx_data(method->rgctx_data, 3))));
		StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6* L_28 = ___2_destination;
		StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6 L_29 = V_1;
		*(StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6*)L_28 = L_29;
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_32, NULL);
		NullCheck(L_31);
		bool L_34;
		L_34 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_31, L_33);
		if (!L_34)
		{
			goto IL_011f;
		}
	}
	{
		StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6* L_35 = ___2_destination;
		Il2CppSharedGenericObject** L_36 = ___1_source;
		Il2CppSharedGenericObject* L_37 = (*(Il2CppSharedGenericObject**)L_36);
		*(StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6*)L_35 = ((*(StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6*)UnBox((RuntimeObject*)L_37, il2cpp_rgctx_data(method->rgctx_data, 3))));
		return (bool)1;
	}

IL_011f:
	{
		goto IL_0177;
	}

IL_0177:
	{
		goto IL_01aa;
	}

IL_01aa:
	{
		bool L_38 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_38)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_39 = ___1_source;
		Il2CppSharedGenericObject* L_40 = (*(Il2CppSharedGenericObject**)L_39);
		if (L_40)
		{
			goto IL_01db;
		}
	}
	{
		StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6* L_41 = ___2_destination;
		il2cpp_codegen_initobj(L_41, sizeof(StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6));
		return (bool)1;
	}

IL_01db:
	{
		StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6* L_42 = ___2_destination;
		il2cpp_codegen_initobj(L_42, sizeof(StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6));
		return (bool)0;
	}
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppSharedGenericObject_TisStyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089_mA32509492DCC599FCB33F28E97803F7C5AB0E925_gshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppSharedGenericObject** ___1_source, StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089* ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089 V_1;
	memset((&V_1), 0, sizeof(V_1));
	TypeConverter_2_tE6C2466AFC58085EAE6299B76802C78CC1C80F0D* V_2 = NULL;
	Il2CppSharedGenericObject* V_3 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_tE6C2466AFC58085EAE6299B76802C78CC1C80F0D*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089* L_7 = ___2_destination;
		TypeConverter_2_tE6C2466AFC58085EAE6299B76802C78CC1C80F0D* L_8 = V_2;
		Il2CppSharedGenericObject** L_9 = ___1_source;
		NullCheck(L_8);
		StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089 L_10;
		L_10 = TypeConverter_2_Invoke_m3927B7CA3A864D22F9C90042FACFAD85E8470864_inline(L_8, L_9, NULL);
		*(StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089*)L_7 = L_10;
		return (bool)1;
	}

IL_0034:
	{
		goto IL_0062;
	}

IL_0062:
	{
		Il2CppSharedGenericObject** L_11 = ___1_source;
		StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089* L_12 = ___2_destination;
		bool L_13;
		L_13 = PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089_mFCB591597B291D0DD02CFE098E32373927D39C14(L_11, L_12, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_13)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppSharedGenericObject** L_14 = ___1_source;
		StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089* L_15 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_16;
		L_16 = TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089_m7F86A21E8CB43CB0D4B5C5B1CFC38574D3A3C0C1(L_14, L_15, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_16)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppSharedGenericObject** L_17 = ___1_source;
		StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089* L_18 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_19;
		L_19 = TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089_m8F64884E8AD78172136BC920DCF5CAF162D57F12(L_17, L_18, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_19)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppSharedGenericObject** L_20 = ___1_source;
		Il2CppSharedGenericObject* L_21 = (*(Il2CppSharedGenericObject**)L_20);
		StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089* L_22 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_23;
		L_23 = TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089_m4EB0464CDB4975842B63C67462BDBB01612FABCB(L_21, L_22, il2cpp_rgctx_method(method->rgctx_data, 10));
		if (!L_23)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		goto IL_00be;
	}

IL_00be:
	{
		Il2CppSharedGenericObject** L_24 = ___1_source;
		Il2CppSharedGenericObject* L_25 = (*(Il2CppSharedGenericObject**)L_24);
		V_3 = L_25;
		Il2CppSharedGenericObject* L_26 = V_3;
		if (!((RuntimeObject*)IsInstSealed((RuntimeObject*)L_26, il2cpp_rgctx_data(method->rgctx_data, 3))))
		{
			goto IL_00ec;
		}
	}
	{
		Il2CppSharedGenericObject* L_27 = V_3;
		V_1 = ((*(StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089*)UnBox(((RuntimeObject*)IsInstSealed((RuntimeObject*)L_27, il2cpp_rgctx_data(method->rgctx_data, 3))), il2cpp_rgctx_data(method->rgctx_data, 3))));
		StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089* L_28 = ___2_destination;
		StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089 L_29 = V_1;
		*(StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089*)L_28 = L_29;
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_32, NULL);
		NullCheck(L_31);
		bool L_34;
		L_34 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_31, L_33);
		if (!L_34)
		{
			goto IL_011f;
		}
	}
	{
		StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089* L_35 = ___2_destination;
		Il2CppSharedGenericObject** L_36 = ___1_source;
		Il2CppSharedGenericObject* L_37 = (*(Il2CppSharedGenericObject**)L_36);
		*(StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089*)L_35 = ((*(StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089*)UnBox((RuntimeObject*)L_37, il2cpp_rgctx_data(method->rgctx_data, 3))));
		return (bool)1;
	}

IL_011f:
	{
		goto IL_0177;
	}

IL_0177:
	{
		goto IL_01aa;
	}

IL_01aa:
	{
		bool L_38 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_38)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_39 = ___1_source;
		Il2CppSharedGenericObject* L_40 = (*(Il2CppSharedGenericObject**)L_39);
		if (L_40)
		{
			goto IL_01db;
		}
	}
	{
		StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089* L_41 = ___2_destination;
		il2cpp_codegen_initobj(L_41, sizeof(StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089));
		return (bool)1;
	}

IL_01db:
	{
		StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089* L_42 = ___2_destination;
		il2cpp_codegen_initobj(L_42, sizeof(StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089));
		return (bool)0;
	}
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppSharedGenericObject_TisStyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5_m0A4C9339A3154C7D9D43919BF23C992406C2C795_gshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppSharedGenericObject** ___1_source, StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5* ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5 V_1;
	memset((&V_1), 0, sizeof(V_1));
	TypeConverter_2_tE2027A3B32E1BB438286300A403B88A772D4E99F* V_2 = NULL;
	Il2CppSharedGenericObject* V_3 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_tE2027A3B32E1BB438286300A403B88A772D4E99F*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5* L_7 = ___2_destination;
		TypeConverter_2_tE2027A3B32E1BB438286300A403B88A772D4E99F* L_8 = V_2;
		Il2CppSharedGenericObject** L_9 = ___1_source;
		NullCheck(L_8);
		StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5 L_10;
		L_10 = TypeConverter_2_Invoke_m66AB21C3C933003F4B10DB738B579AFF92767A3D_inline(L_8, L_9, NULL);
		*(StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5*)L_7 = L_10;
		Il2CppCodeGenWriteBarrier((void**)&(((StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5*)L_7)->___m_Value), (void*)NULL);
		return (bool)1;
	}

IL_0034:
	{
		goto IL_0062;
	}

IL_0062:
	{
		Il2CppSharedGenericObject** L_11 = ___1_source;
		StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5* L_12 = ___2_destination;
		bool L_13;
		L_13 = PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisStyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5_m564B93B9344A01B1A52075D1912BEF406EC84E87(L_11, L_12, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_13)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppSharedGenericObject** L_14 = ___1_source;
		StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5* L_15 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_16;
		L_16 = TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisStyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5_m3227677FE5E7EDA4602AF0D303E44A200D8AA66E(L_14, L_15, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_16)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppSharedGenericObject** L_17 = ___1_source;
		StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5* L_18 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_19;
		L_19 = TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisStyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5_m6D805B2A00A84AC4C86C865C3B0460DC556F4E42(L_17, L_18, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_19)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppSharedGenericObject** L_20 = ___1_source;
		Il2CppSharedGenericObject* L_21 = (*(Il2CppSharedGenericObject**)L_20);
		StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5* L_22 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_23;
		L_23 = TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisStyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5_mA1B091C8410E7B6B77A87FB8193CA30DC21D4F7D(L_21, L_22, il2cpp_rgctx_method(method->rgctx_data, 10));
		if (!L_23)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		goto IL_00be;
	}

IL_00be:
	{
		Il2CppSharedGenericObject** L_24 = ___1_source;
		Il2CppSharedGenericObject* L_25 = (*(Il2CppSharedGenericObject**)L_24);
		V_3 = L_25;
		Il2CppSharedGenericObject* L_26 = V_3;
		if (!((RuntimeObject*)IsInstSealed((RuntimeObject*)L_26, il2cpp_rgctx_data(method->rgctx_data, 3))))
		{
			goto IL_00ec;
		}
	}
	{
		Il2CppSharedGenericObject* L_27 = V_3;
		V_1 = ((*(StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5*)UnBox(((RuntimeObject*)IsInstSealed((RuntimeObject*)L_27, il2cpp_rgctx_data(method->rgctx_data, 3))), il2cpp_rgctx_data(method->rgctx_data, 3))));
		StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5* L_28 = ___2_destination;
		StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5 L_29 = V_1;
		*(StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5*)L_28 = L_29;
		Il2CppCodeGenWriteBarrier((void**)&(((StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5*)L_28)->___m_Value), (void*)NULL);
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_32, NULL);
		NullCheck(L_31);
		bool L_34;
		L_34 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_31, L_33);
		if (!L_34)
		{
			goto IL_011f;
		}
	}
	{
		StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5* L_35 = ___2_destination;
		Il2CppSharedGenericObject** L_36 = ___1_source;
		Il2CppSharedGenericObject* L_37 = (*(Il2CppSharedGenericObject**)L_36);
		*(StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5*)L_35 = ((*(StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5*)UnBox((RuntimeObject*)L_37, il2cpp_rgctx_data(method->rgctx_data, 3))));
		Il2CppCodeGenWriteBarrier((void**)&(((StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5*)L_35)->___m_Value), (void*)NULL);
		return (bool)1;
	}

IL_011f:
	{
		goto IL_0177;
	}

IL_0177:
	{
		goto IL_01aa;
	}

IL_01aa:
	{
		bool L_38 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_38)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_39 = ___1_source;
		Il2CppSharedGenericObject* L_40 = (*(Il2CppSharedGenericObject**)L_39);
		if (L_40)
		{
			goto IL_01db;
		}
	}
	{
		StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5* L_41 = ___2_destination;
		il2cpp_codegen_initobj(L_41, sizeof(StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5));
		return (bool)1;
	}

IL_01db:
	{
		StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5* L_42 = ___2_destination;
		il2cpp_codegen_initobj(L_42, sizeof(StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5));
		return (bool)0;
	}
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppSharedGenericObject_TisTextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A_m2C8308EFB30564F9C183A39F3C07E98CE2D0F9EB_gshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppSharedGenericObject** ___1_source, TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A* ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A V_1;
	memset((&V_1), 0, sizeof(V_1));
	TypeConverter_2_t73501A4CF3B35838D78DF2D56FF13675BEADC04B* V_2 = NULL;
	Il2CppSharedGenericObject* V_3 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_t73501A4CF3B35838D78DF2D56FF13675BEADC04B*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A* L_7 = ___2_destination;
		TypeConverter_2_t73501A4CF3B35838D78DF2D56FF13675BEADC04B* L_8 = V_2;
		Il2CppSharedGenericObject** L_9 = ___1_source;
		NullCheck(L_8);
		TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A L_10;
		L_10 = TypeConverter_2_Invoke_mE56444FC16A71452E074A8C12A28AEE28120D830_inline(L_8, L_9, NULL);
		*(TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A*)L_7 = L_10;
		return (bool)1;
	}

IL_0034:
	{
		goto IL_0062;
	}

IL_0062:
	{
		Il2CppSharedGenericObject** L_11 = ___1_source;
		TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A* L_12 = ___2_destination;
		bool L_13;
		L_13 = PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisTextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A_mEEB83B2B4E5614452D4D2A8725EB634658C31DBC(L_11, L_12, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_13)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppSharedGenericObject** L_14 = ___1_source;
		TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A* L_15 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_16;
		L_16 = TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisTextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A_mBC72FAD802D2847DCD9F992F3F55C241F65D44F1(L_14, L_15, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_16)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppSharedGenericObject** L_17 = ___1_source;
		TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A* L_18 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_19;
		L_19 = TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisTextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A_m88C9AF679301ABB958D4D24E822A33521E08FFD3(L_17, L_18, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_19)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppSharedGenericObject** L_20 = ___1_source;
		Il2CppSharedGenericObject* L_21 = (*(Il2CppSharedGenericObject**)L_20);
		TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A* L_22 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_23;
		L_23 = TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisTextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A_mAF37628D99B7AE42B9420533D24C7F5F7B94D986(L_21, L_22, il2cpp_rgctx_method(method->rgctx_data, 10));
		if (!L_23)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		goto IL_00be;
	}

IL_00be:
	{
		Il2CppSharedGenericObject** L_24 = ___1_source;
		Il2CppSharedGenericObject* L_25 = (*(Il2CppSharedGenericObject**)L_24);
		V_3 = L_25;
		Il2CppSharedGenericObject* L_26 = V_3;
		if (!((RuntimeObject*)IsInstSealed((RuntimeObject*)L_26, il2cpp_rgctx_data(method->rgctx_data, 3))))
		{
			goto IL_00ec;
		}
	}
	{
		Il2CppSharedGenericObject* L_27 = V_3;
		V_1 = ((*(TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A*)UnBox(((RuntimeObject*)IsInstSealed((RuntimeObject*)L_27, il2cpp_rgctx_data(method->rgctx_data, 3))), il2cpp_rgctx_data(method->rgctx_data, 3))));
		TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A* L_28 = ___2_destination;
		TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A L_29 = V_1;
		*(TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A*)L_28 = L_29;
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_32, NULL);
		NullCheck(L_31);
		bool L_34;
		L_34 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_31, L_33);
		if (!L_34)
		{
			goto IL_011f;
		}
	}
	{
		TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A* L_35 = ___2_destination;
		Il2CppSharedGenericObject** L_36 = ___1_source;
		Il2CppSharedGenericObject* L_37 = (*(Il2CppSharedGenericObject**)L_36);
		*(TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A*)L_35 = ((*(TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A*)UnBox((RuntimeObject*)L_37, il2cpp_rgctx_data(method->rgctx_data, 3))));
		return (bool)1;
	}

IL_011f:
	{
		goto IL_0177;
	}

IL_0177:
	{
		goto IL_01aa;
	}

IL_01aa:
	{
		bool L_38 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_38)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_39 = ___1_source;
		Il2CppSharedGenericObject* L_40 = (*(Il2CppSharedGenericObject**)L_39);
		if (L_40)
		{
			goto IL_01db;
		}
	}
	{
		TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A* L_41 = ___2_destination;
		il2cpp_codegen_initobj(L_41, sizeof(TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A));
		return (bool)1;
	}

IL_01db:
	{
		TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A* L_42 = ___2_destination;
		il2cpp_codegen_initobj(L_42, sizeof(TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A));
		return (bool)0;
	}
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppSharedGenericObject_TisTextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05_mB23A1A2F0EE3AF7943B93ECF5D3FD7A38BC32E30_gshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppSharedGenericObject** ___1_source, TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05* ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05 V_1;
	memset((&V_1), 0, sizeof(V_1));
	TypeConverter_2_tC0A832D8646E8260644D66DD7FA213AC57484831* V_2 = NULL;
	Il2CppSharedGenericObject* V_3 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_tC0A832D8646E8260644D66DD7FA213AC57484831*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05* L_7 = ___2_destination;
		TypeConverter_2_tC0A832D8646E8260644D66DD7FA213AC57484831* L_8 = V_2;
		Il2CppSharedGenericObject** L_9 = ___1_source;
		NullCheck(L_8);
		TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05 L_10;
		L_10 = TypeConverter_2_Invoke_m5EFB8A4B526E5038BBEB12C50358AA67406DC302_inline(L_8, L_9, NULL);
		*(TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05*)L_7 = L_10;
		return (bool)1;
	}

IL_0034:
	{
		goto IL_0062;
	}

IL_0062:
	{
		Il2CppSharedGenericObject** L_11 = ___1_source;
		TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05* L_12 = ___2_destination;
		bool L_13;
		L_13 = PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisTextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05_m8E83833ECA82E697F7024DC7070AC6128A018B76(L_11, L_12, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_13)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppSharedGenericObject** L_14 = ___1_source;
		TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05* L_15 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_16;
		L_16 = TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisTextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05_m7EADBF9FD32CFE1F86F36BAF4839C307E7B54042(L_14, L_15, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_16)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppSharedGenericObject** L_17 = ___1_source;
		TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05* L_18 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_19;
		L_19 = TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisTextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05_m77C51931C4EDB1902C16349B4C4D9BC785E6DEC0(L_17, L_18, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_19)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppSharedGenericObject** L_20 = ___1_source;
		Il2CppSharedGenericObject* L_21 = (*(Il2CppSharedGenericObject**)L_20);
		TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05* L_22 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_23;
		L_23 = TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisTextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05_m05759354955D3A449C3EB327B9D0FC2995D78A16(L_21, L_22, il2cpp_rgctx_method(method->rgctx_data, 10));
		if (!L_23)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		goto IL_00be;
	}

IL_00be:
	{
		Il2CppSharedGenericObject** L_24 = ___1_source;
		Il2CppSharedGenericObject* L_25 = (*(Il2CppSharedGenericObject**)L_24);
		V_3 = L_25;
		Il2CppSharedGenericObject* L_26 = V_3;
		if (!((RuntimeObject*)IsInstSealed((RuntimeObject*)L_26, il2cpp_rgctx_data(method->rgctx_data, 3))))
		{
			goto IL_00ec;
		}
	}
	{
		Il2CppSharedGenericObject* L_27 = V_3;
		V_1 = ((*(TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05*)UnBox(((RuntimeObject*)IsInstSealed((RuntimeObject*)L_27, il2cpp_rgctx_data(method->rgctx_data, 3))), il2cpp_rgctx_data(method->rgctx_data, 3))));
		TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05* L_28 = ___2_destination;
		TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05 L_29 = V_1;
		*(TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05*)L_28 = L_29;
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_32, NULL);
		NullCheck(L_31);
		bool L_34;
		L_34 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_31, L_33);
		if (!L_34)
		{
			goto IL_011f;
		}
	}
	{
		TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05* L_35 = ___2_destination;
		Il2CppSharedGenericObject** L_36 = ___1_source;
		Il2CppSharedGenericObject* L_37 = (*(Il2CppSharedGenericObject**)L_36);
		*(TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05*)L_35 = ((*(TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05*)UnBox((RuntimeObject*)L_37, il2cpp_rgctx_data(method->rgctx_data, 3))));
		return (bool)1;
	}

IL_011f:
	{
		goto IL_0177;
	}

IL_0177:
	{
		goto IL_01aa;
	}

IL_01aa:
	{
		bool L_38 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_38)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_39 = ___1_source;
		Il2CppSharedGenericObject* L_40 = (*(Il2CppSharedGenericObject**)L_39);
		if (L_40)
		{
			goto IL_01db;
		}
	}
	{
		TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05* L_41 = ___2_destination;
		il2cpp_codegen_initobj(L_41, sizeof(TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05));
		return (bool)1;
	}

IL_01db:
	{
		TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05* L_42 = ___2_destination;
		il2cpp_codegen_initobj(L_42, sizeof(TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05));
		return (bool)0;
	}
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppSharedGenericObject_TisTimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_m128C2BE79515DE4C2B10FA2A8A4249000B98AF29_gshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppSharedGenericObject** ___1_source, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A V_1;
	memset((&V_1), 0, sizeof(V_1));
	TypeConverter_2_t0A5CBF00DFB82526AEB7B2DFEF71CA4F4807581E* V_2 = NULL;
	Il2CppSharedGenericObject* V_3 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_t0A5CBF00DFB82526AEB7B2DFEF71CA4F4807581E*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* L_7 = ___2_destination;
		TypeConverter_2_t0A5CBF00DFB82526AEB7B2DFEF71CA4F4807581E* L_8 = V_2;
		Il2CppSharedGenericObject** L_9 = ___1_source;
		NullCheck(L_8);
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_10;
		L_10 = TypeConverter_2_Invoke_m8A30F6853F5EE6FCFDE935B43D200CCAA09136B4_inline(L_8, L_9, NULL);
		*(TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A*)L_7 = L_10;
		return (bool)1;
	}

IL_0034:
	{
		goto IL_0062;
	}

IL_0062:
	{
		Il2CppSharedGenericObject** L_11 = ___1_source;
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* L_12 = ___2_destination;
		bool L_13;
		L_13 = PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisTimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_mABD8E4CDEF3C53E49935B66E044F8D4A232A3D03(L_11, L_12, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_13)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppSharedGenericObject** L_14 = ___1_source;
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* L_15 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_16;
		L_16 = TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisTimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_m069CFAFE812619C0986B6D70996F30B2A4F8B9BC(L_14, L_15, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_16)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppSharedGenericObject** L_17 = ___1_source;
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* L_18 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_19;
		L_19 = TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisTimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_mA65027452747D38D73A877E1C21175A015F9177A(L_17, L_18, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_19)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppSharedGenericObject** L_20 = ___1_source;
		Il2CppSharedGenericObject* L_21 = (*(Il2CppSharedGenericObject**)L_20);
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* L_22 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_23;
		L_23 = TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisTimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_mCE6A94094E0147E3D6D83D9EED5C942FA998BBFC(L_21, L_22, il2cpp_rgctx_method(method->rgctx_data, 10));
		if (!L_23)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		goto IL_00be;
	}

IL_00be:
	{
		Il2CppSharedGenericObject** L_24 = ___1_source;
		Il2CppSharedGenericObject* L_25 = (*(Il2CppSharedGenericObject**)L_24);
		V_3 = L_25;
		Il2CppSharedGenericObject* L_26 = V_3;
		if (!((RuntimeObject*)IsInstSealed((RuntimeObject*)L_26, il2cpp_rgctx_data(method->rgctx_data, 3))))
		{
			goto IL_00ec;
		}
	}
	{
		Il2CppSharedGenericObject* L_27 = V_3;
		V_1 = ((*(TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A*)UnBox(((RuntimeObject*)IsInstSealed((RuntimeObject*)L_27, il2cpp_rgctx_data(method->rgctx_data, 3))), il2cpp_rgctx_data(method->rgctx_data, 3))));
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* L_28 = ___2_destination;
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A L_29 = V_1;
		*(TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A*)L_28 = L_29;
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_32, NULL);
		NullCheck(L_31);
		bool L_34;
		L_34 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_31, L_33);
		if (!L_34)
		{
			goto IL_011f;
		}
	}
	{
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* L_35 = ___2_destination;
		Il2CppSharedGenericObject** L_36 = ___1_source;
		Il2CppSharedGenericObject* L_37 = (*(Il2CppSharedGenericObject**)L_36);
		*(TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A*)L_35 = ((*(TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A*)UnBox((RuntimeObject*)L_37, il2cpp_rgctx_data(method->rgctx_data, 3))));
		return (bool)1;
	}

IL_011f:
	{
		goto IL_0177;
	}

IL_0177:
	{
		goto IL_01aa;
	}

IL_01aa:
	{
		bool L_38 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_38)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_39 = ___1_source;
		Il2CppSharedGenericObject* L_40 = (*(Il2CppSharedGenericObject**)L_39);
		if (L_40)
		{
			goto IL_01db;
		}
	}
	{
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* L_41 = ___2_destination;
		il2cpp_codegen_initobj(L_41, sizeof(TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A));
		return (bool)1;
	}

IL_01db:
	{
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* L_42 = ___2_destination;
		il2cpp_codegen_initobj(L_42, sizeof(TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A));
		return (bool)0;
	}
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppSharedGenericObject_TisTimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E_mCEF2F6963B130FDCA6897F8D60B71886D08B3580_gshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppSharedGenericObject** ___1_source, TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E* ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E V_1;
	memset((&V_1), 0, sizeof(V_1));
	TypeConverter_2_tBA10E08FB2B7207E85EAB1039CE76A8D80224B20* V_2 = NULL;
	Il2CppSharedGenericObject* V_3 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_tBA10E08FB2B7207E85EAB1039CE76A8D80224B20*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E* L_7 = ___2_destination;
		TypeConverter_2_tBA10E08FB2B7207E85EAB1039CE76A8D80224B20* L_8 = V_2;
		Il2CppSharedGenericObject** L_9 = ___1_source;
		NullCheck(L_8);
		TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E L_10;
		L_10 = TypeConverter_2_Invoke_mDFB5642B7FB6B4442DBC14B2F31EF44601F04D38_inline(L_8, L_9, NULL);
		*(TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E*)L_7 = L_10;
		return (bool)1;
	}

IL_0034:
	{
		goto IL_0062;
	}

IL_0062:
	{
		Il2CppSharedGenericObject** L_11 = ___1_source;
		TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E* L_12 = ___2_destination;
		bool L_13;
		L_13 = PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisTimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E_m1B1B4E79A79CB4606C4FCD10011C3C1E9C491B4F(L_11, L_12, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_13)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppSharedGenericObject** L_14 = ___1_source;
		TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E* L_15 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_16;
		L_16 = TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisTimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E_mDC3DBAD282E45562925459BB094157FE8D7A39B1(L_14, L_15, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_16)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppSharedGenericObject** L_17 = ___1_source;
		TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E* L_18 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_19;
		L_19 = TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisTimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E_m5050A815DCF77923C0D3454F0E2464A0CC9C2D12(L_17, L_18, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_19)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppSharedGenericObject** L_20 = ___1_source;
		Il2CppSharedGenericObject* L_21 = (*(Il2CppSharedGenericObject**)L_20);
		TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E* L_22 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_23;
		L_23 = TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisTimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E_m890F9B74999D7F62E686CB9028C19252CF5B3162(L_21, L_22, il2cpp_rgctx_method(method->rgctx_data, 10));
		if (!L_23)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		goto IL_00be;
	}

IL_00be:
	{
		Il2CppSharedGenericObject** L_24 = ___1_source;
		Il2CppSharedGenericObject* L_25 = (*(Il2CppSharedGenericObject**)L_24);
		V_3 = L_25;
		Il2CppSharedGenericObject* L_26 = V_3;
		if (!((RuntimeObject*)IsInstSealed((RuntimeObject*)L_26, il2cpp_rgctx_data(method->rgctx_data, 3))))
		{
			goto IL_00ec;
		}
	}
	{
		Il2CppSharedGenericObject* L_27 = V_3;
		V_1 = ((*(TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E*)UnBox(((RuntimeObject*)IsInstSealed((RuntimeObject*)L_27, il2cpp_rgctx_data(method->rgctx_data, 3))), il2cpp_rgctx_data(method->rgctx_data, 3))));
		TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E* L_28 = ___2_destination;
		TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E L_29 = V_1;
		*(TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E*)L_28 = L_29;
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_32, NULL);
		NullCheck(L_31);
		bool L_34;
		L_34 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_31, L_33);
		if (!L_34)
		{
			goto IL_011f;
		}
	}
	{
		TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E* L_35 = ___2_destination;
		Il2CppSharedGenericObject** L_36 = ___1_source;
		Il2CppSharedGenericObject* L_37 = (*(Il2CppSharedGenericObject**)L_36);
		*(TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E*)L_35 = ((*(TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E*)UnBox((RuntimeObject*)L_37, il2cpp_rgctx_data(method->rgctx_data, 3))));
		return (bool)1;
	}

IL_011f:
	{
		goto IL_0177;
	}

IL_0177:
	{
		goto IL_01aa;
	}

IL_01aa:
	{
		bool L_38 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_38)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_39 = ___1_source;
		Il2CppSharedGenericObject* L_40 = (*(Il2CppSharedGenericObject**)L_39);
		if (L_40)
		{
			goto IL_01db;
		}
	}
	{
		TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E* L_41 = ___2_destination;
		il2cpp_codegen_initobj(L_41, sizeof(TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E));
		return (bool)1;
	}

IL_01db:
	{
		TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E* L_42 = ___2_destination;
		il2cpp_codegen_initobj(L_42, sizeof(TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E));
		return (bool)0;
	}
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppSharedGenericObject_TisTransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502_mDAC8B9FE0C533CF6F762CD4D1E194D7383DDAA28_gshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppSharedGenericObject** ___1_source, TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502* ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502 V_1;
	memset((&V_1), 0, sizeof(V_1));
	TypeConverter_2_t26D60543337DCCA819FD538D85F40D86762DB0F2* V_2 = NULL;
	Il2CppSharedGenericObject* V_3 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_t26D60543337DCCA819FD538D85F40D86762DB0F2*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502* L_7 = ___2_destination;
		TypeConverter_2_t26D60543337DCCA819FD538D85F40D86762DB0F2* L_8 = V_2;
		Il2CppSharedGenericObject** L_9 = ___1_source;
		NullCheck(L_8);
		TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502 L_10;
		L_10 = TypeConverter_2_Invoke_mCE58430324F9B994275CA0432152E6690C870493_inline(L_8, L_9, NULL);
		*(TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502*)L_7 = L_10;
		return (bool)1;
	}

IL_0034:
	{
		goto IL_0062;
	}

IL_0062:
	{
		Il2CppSharedGenericObject** L_11 = ___1_source;
		TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502* L_12 = ___2_destination;
		bool L_13;
		L_13 = PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisTransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502_m86DA4A09ED739EC95D08078C2A68B5D3B2331B4D(L_11, L_12, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_13)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppSharedGenericObject** L_14 = ___1_source;
		TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502* L_15 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_16;
		L_16 = TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisTransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502_m43E97D6A9927E5D80F447A939DECC30242168E99(L_14, L_15, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_16)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppSharedGenericObject** L_17 = ___1_source;
		TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502* L_18 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_19;
		L_19 = TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisTransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502_mC73284DDA65769315166572B6F9EBBB09FD66BAC(L_17, L_18, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_19)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppSharedGenericObject** L_20 = ___1_source;
		Il2CppSharedGenericObject* L_21 = (*(Il2CppSharedGenericObject**)L_20);
		TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502* L_22 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_23;
		L_23 = TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisTransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502_mF9CB9E3DF63B70278C7644C14E87765DFF86202E(L_21, L_22, il2cpp_rgctx_method(method->rgctx_data, 10));
		if (!L_23)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		goto IL_00be;
	}

IL_00be:
	{
		Il2CppSharedGenericObject** L_24 = ___1_source;
		Il2CppSharedGenericObject* L_25 = (*(Il2CppSharedGenericObject**)L_24);
		V_3 = L_25;
		Il2CppSharedGenericObject* L_26 = V_3;
		if (!((RuntimeObject*)IsInstSealed((RuntimeObject*)L_26, il2cpp_rgctx_data(method->rgctx_data, 3))))
		{
			goto IL_00ec;
		}
	}
	{
		Il2CppSharedGenericObject* L_27 = V_3;
		V_1 = ((*(TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502*)UnBox(((RuntimeObject*)IsInstSealed((RuntimeObject*)L_27, il2cpp_rgctx_data(method->rgctx_data, 3))), il2cpp_rgctx_data(method->rgctx_data, 3))));
		TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502* L_28 = ___2_destination;
		TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502 L_29 = V_1;
		*(TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502*)L_28 = L_29;
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_32, NULL);
		NullCheck(L_31);
		bool L_34;
		L_34 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_31, L_33);
		if (!L_34)
		{
			goto IL_011f;
		}
	}
	{
		TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502* L_35 = ___2_destination;
		Il2CppSharedGenericObject** L_36 = ___1_source;
		Il2CppSharedGenericObject* L_37 = (*(Il2CppSharedGenericObject**)L_36);
		*(TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502*)L_35 = ((*(TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502*)UnBox((RuntimeObject*)L_37, il2cpp_rgctx_data(method->rgctx_data, 3))));
		return (bool)1;
	}

IL_011f:
	{
		goto IL_0177;
	}

IL_0177:
	{
		goto IL_01aa;
	}

IL_01aa:
	{
		bool L_38 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_38)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_39 = ___1_source;
		Il2CppSharedGenericObject* L_40 = (*(Il2CppSharedGenericObject**)L_39);
		if (L_40)
		{
			goto IL_01db;
		}
	}
	{
		TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502* L_41 = ___2_destination;
		il2cpp_codegen_initobj(L_41, sizeof(TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502));
		return (bool)1;
	}

IL_01db:
	{
		TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502* L_42 = ___2_destination;
		il2cpp_codegen_initobj(L_42, sizeof(TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502));
		return (bool)0;
	}
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppSharedGenericObject_TisTranslate_t494F6E802F8A640D67819C9D26BE62DED1218A8E_mBDEE14810EC9089A344DC86B6D870F71A1AF373C_gshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppSharedGenericObject** ___1_source, Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E* ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E V_1;
	memset((&V_1), 0, sizeof(V_1));
	TypeConverter_2_tC8DC9C48FBE571CF2E75D0324F34468EACBEB008* V_2 = NULL;
	Il2CppSharedGenericObject* V_3 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_tC8DC9C48FBE571CF2E75D0324F34468EACBEB008*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E* L_7 = ___2_destination;
		TypeConverter_2_tC8DC9C48FBE571CF2E75D0324F34468EACBEB008* L_8 = V_2;
		Il2CppSharedGenericObject** L_9 = ___1_source;
		NullCheck(L_8);
		Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E L_10;
		L_10 = TypeConverter_2_Invoke_mD793CD9960E098A5D8B04701404212678B3C4087_inline(L_8, L_9, NULL);
		*(Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E*)L_7 = L_10;
		return (bool)1;
	}

IL_0034:
	{
		goto IL_0062;
	}

IL_0062:
	{
		Il2CppSharedGenericObject** L_11 = ___1_source;
		Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E* L_12 = ___2_destination;
		bool L_13;
		L_13 = PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisTranslate_t494F6E802F8A640D67819C9D26BE62DED1218A8E_m59519C17558F8D8E4F1351404BEA83B969C19120(L_11, L_12, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_13)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppSharedGenericObject** L_14 = ___1_source;
		Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E* L_15 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_16;
		L_16 = TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisTranslate_t494F6E802F8A640D67819C9D26BE62DED1218A8E_mE693B7D7A19E1DC6276F1A46097436590B6C96E4(L_14, L_15, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_16)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppSharedGenericObject** L_17 = ___1_source;
		Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E* L_18 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_19;
		L_19 = TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisTranslate_t494F6E802F8A640D67819C9D26BE62DED1218A8E_mF43635F25DDF8116F489001592D21F5AC5264A15(L_17, L_18, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_19)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppSharedGenericObject** L_20 = ___1_source;
		Il2CppSharedGenericObject* L_21 = (*(Il2CppSharedGenericObject**)L_20);
		Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E* L_22 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_23;
		L_23 = TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisTranslate_t494F6E802F8A640D67819C9D26BE62DED1218A8E_m15BCEE9792C8945FDE5437EC42A3AEC4C84FDC99(L_21, L_22, il2cpp_rgctx_method(method->rgctx_data, 10));
		if (!L_23)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		goto IL_00be;
	}

IL_00be:
	{
		Il2CppSharedGenericObject** L_24 = ___1_source;
		Il2CppSharedGenericObject* L_25 = (*(Il2CppSharedGenericObject**)L_24);
		V_3 = L_25;
		Il2CppSharedGenericObject* L_26 = V_3;
		if (!((RuntimeObject*)IsInstSealed((RuntimeObject*)L_26, il2cpp_rgctx_data(method->rgctx_data, 3))))
		{
			goto IL_00ec;
		}
	}
	{
		Il2CppSharedGenericObject* L_27 = V_3;
		V_1 = ((*(Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E*)UnBox(((RuntimeObject*)IsInstSealed((RuntimeObject*)L_27, il2cpp_rgctx_data(method->rgctx_data, 3))), il2cpp_rgctx_data(method->rgctx_data, 3))));
		Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E* L_28 = ___2_destination;
		Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E L_29 = V_1;
		*(Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E*)L_28 = L_29;
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_32, NULL);
		NullCheck(L_31);
		bool L_34;
		L_34 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_31, L_33);
		if (!L_34)
		{
			goto IL_011f;
		}
	}
	{
		Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E* L_35 = ___2_destination;
		Il2CppSharedGenericObject** L_36 = ___1_source;
		Il2CppSharedGenericObject* L_37 = (*(Il2CppSharedGenericObject**)L_36);
		*(Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E*)L_35 = ((*(Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E*)UnBox((RuntimeObject*)L_37, il2cpp_rgctx_data(method->rgctx_data, 3))));
		return (bool)1;
	}

IL_011f:
	{
		goto IL_0177;
	}

IL_0177:
	{
		goto IL_01aa;
	}

IL_01aa:
	{
		bool L_38 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_38)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_39 = ___1_source;
		Il2CppSharedGenericObject* L_40 = (*(Il2CppSharedGenericObject**)L_39);
		if (L_40)
		{
			goto IL_01db;
		}
	}
	{
		Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E* L_41 = ___2_destination;
		il2cpp_codegen_initobj(L_41, sizeof(Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E));
		return (bool)1;
	}

IL_01db:
	{
		Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E* L_42 = ___2_destination;
		il2cpp_codegen_initobj(L_42, sizeof(Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E));
		return (bool)0;
	}
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppSharedGenericObject_TisUInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_mB4942EE5FB15745C0670AF2F593DACBC23B0B32E_gshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppSharedGenericObject** ___1_source, uint16_t* ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	uint16_t V_1 = 0;
	TypeConverter_2_t7104BAD86AB01041A6B4CFA05DD8A0CF7B316EAE* V_2 = NULL;
	Il2CppSharedGenericObject* V_3 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_t7104BAD86AB01041A6B4CFA05DD8A0CF7B316EAE*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		uint16_t* L_7 = ___2_destination;
		TypeConverter_2_t7104BAD86AB01041A6B4CFA05DD8A0CF7B316EAE* L_8 = V_2;
		Il2CppSharedGenericObject** L_9 = ___1_source;
		NullCheck(L_8);
		uint16_t L_10;
		L_10 = TypeConverter_2_Invoke_m66222088B81B0479C4FAED81A6E115C2078D89A2_inline(L_8, L_9, NULL);
		*(uint16_t*)L_7 = L_10;
		return (bool)1;
	}

IL_0034:
	{
		goto IL_0062;
	}

IL_0062:
	{
		Il2CppSharedGenericObject** L_11 = ___1_source;
		uint16_t* L_12 = ___2_destination;
		bool L_13;
		L_13 = PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisUInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_mDA8A246BC062B5634F667D514235205969506D53(L_11, L_12, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_13)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppSharedGenericObject** L_14 = ___1_source;
		uint16_t* L_15 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_16;
		L_16 = TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisUInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_m65E9FB7FA0D01A0CD52BDA1F0FD39CE635D5CF9B(L_14, L_15, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_16)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppSharedGenericObject** L_17 = ___1_source;
		uint16_t* L_18 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_19;
		L_19 = TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisUInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_m7044D1087F56C3448C4455C14F31DD12DFA2A2FF(L_17, L_18, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_19)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppSharedGenericObject** L_20 = ___1_source;
		Il2CppSharedGenericObject* L_21 = (*(Il2CppSharedGenericObject**)L_20);
		uint16_t* L_22 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_23;
		L_23 = TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisUInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_m0CF638A658A95329981CFE92A200F9F026CC88BF(L_21, L_22, il2cpp_rgctx_method(method->rgctx_data, 10));
		if (!L_23)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		goto IL_00be;
	}

IL_00be:
	{
		Il2CppSharedGenericObject** L_24 = ___1_source;
		Il2CppSharedGenericObject* L_25 = (*(Il2CppSharedGenericObject**)L_24);
		V_3 = L_25;
		Il2CppSharedGenericObject* L_26 = V_3;
		if (!((RuntimeObject*)IsInstSealed((RuntimeObject*)L_26, il2cpp_rgctx_data(method->rgctx_data, 3))))
		{
			goto IL_00ec;
		}
	}
	{
		Il2CppSharedGenericObject* L_27 = V_3;
		V_1 = ((*(uint16_t*)UnBox(((RuntimeObject*)IsInstSealed((RuntimeObject*)L_27, il2cpp_rgctx_data(method->rgctx_data, 3))), il2cpp_rgctx_data(method->rgctx_data, 3))));
		uint16_t* L_28 = ___2_destination;
		uint16_t L_29 = V_1;
		*(uint16_t*)L_28 = L_29;
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_32, NULL);
		NullCheck(L_31);
		bool L_34;
		L_34 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_31, L_33);
		if (!L_34)
		{
			goto IL_011f;
		}
	}
	{
		uint16_t* L_35 = ___2_destination;
		Il2CppSharedGenericObject** L_36 = ___1_source;
		Il2CppSharedGenericObject* L_37 = (*(Il2CppSharedGenericObject**)L_36);
		*(uint16_t*)L_35 = ((*(uint16_t*)UnBox((RuntimeObject*)L_37, il2cpp_rgctx_data(method->rgctx_data, 3))));
		return (bool)1;
	}

IL_011f:
	{
		goto IL_0177;
	}

IL_0177:
	{
		goto IL_01aa;
	}

IL_01aa:
	{
		bool L_38 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_38)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_39 = ___1_source;
		Il2CppSharedGenericObject* L_40 = (*(Il2CppSharedGenericObject**)L_39);
		if (L_40)
		{
			goto IL_01db;
		}
	}
	{
		uint16_t* L_41 = ___2_destination;
		il2cpp_codegen_initobj(L_41, sizeof(uint16_t));
		return (bool)1;
	}

IL_01db:
	{
		uint16_t* L_42 = ___2_destination;
		il2cpp_codegen_initobj(L_42, sizeof(uint16_t));
		return (bool)0;
	}
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppSharedGenericObject_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_mB54B1BD1179A67AF660EAC8D2BDD7D93339926C1_gshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppSharedGenericObject** ___1_source, uint32_t* ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	uint32_t V_1 = 0;
	TypeConverter_2_t987BA7DD2FE661C6A4CD1CE7F398720A1A912CDB* V_2 = NULL;
	Il2CppSharedGenericObject* V_3 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_t987BA7DD2FE661C6A4CD1CE7F398720A1A912CDB*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		uint32_t* L_7 = ___2_destination;
		TypeConverter_2_t987BA7DD2FE661C6A4CD1CE7F398720A1A912CDB* L_8 = V_2;
		Il2CppSharedGenericObject** L_9 = ___1_source;
		NullCheck(L_8);
		uint32_t L_10;
		L_10 = TypeConverter_2_Invoke_mCBE8A03AC2A93E11AC276C8AB69B069E2DC24E9F_inline(L_8, L_9, NULL);
		*(uint32_t*)L_7 = L_10;
		return (bool)1;
	}

IL_0034:
	{
		goto IL_0062;
	}

IL_0062:
	{
		Il2CppSharedGenericObject** L_11 = ___1_source;
		uint32_t* L_12 = ___2_destination;
		bool L_13;
		L_13 = PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_mC57548E2FBB7801ADCA39608D4B49D6B97974514(L_11, L_12, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_13)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppSharedGenericObject** L_14 = ___1_source;
		uint32_t* L_15 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_16;
		L_16 = TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_m06E5488A389513768C081F56CFDE78AC028D9C43(L_14, L_15, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_16)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppSharedGenericObject** L_17 = ___1_source;
		uint32_t* L_18 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_19;
		L_19 = TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_m55BEAE3C511900D8ED0BA0D28D3F54CE3676D84C(L_17, L_18, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_19)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppSharedGenericObject** L_20 = ___1_source;
		Il2CppSharedGenericObject* L_21 = (*(Il2CppSharedGenericObject**)L_20);
		uint32_t* L_22 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_23;
		L_23 = TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_mC43EF7862142C0A1290BAC84D392D044737CAF02(L_21, L_22, il2cpp_rgctx_method(method->rgctx_data, 10));
		if (!L_23)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		goto IL_00be;
	}

IL_00be:
	{
		Il2CppSharedGenericObject** L_24 = ___1_source;
		Il2CppSharedGenericObject* L_25 = (*(Il2CppSharedGenericObject**)L_24);
		V_3 = L_25;
		Il2CppSharedGenericObject* L_26 = V_3;
		if (!((RuntimeObject*)IsInstSealed((RuntimeObject*)L_26, il2cpp_rgctx_data(method->rgctx_data, 3))))
		{
			goto IL_00ec;
		}
	}
	{
		Il2CppSharedGenericObject* L_27 = V_3;
		V_1 = ((*(uint32_t*)UnBox(((RuntimeObject*)IsInstSealed((RuntimeObject*)L_27, il2cpp_rgctx_data(method->rgctx_data, 3))), il2cpp_rgctx_data(method->rgctx_data, 3))));
		uint32_t* L_28 = ___2_destination;
		uint32_t L_29 = V_1;
		*(uint32_t*)L_28 = L_29;
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_32, NULL);
		NullCheck(L_31);
		bool L_34;
		L_34 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_31, L_33);
		if (!L_34)
		{
			goto IL_011f;
		}
	}
	{
		uint32_t* L_35 = ___2_destination;
		Il2CppSharedGenericObject** L_36 = ___1_source;
		Il2CppSharedGenericObject* L_37 = (*(Il2CppSharedGenericObject**)L_36);
		*(uint32_t*)L_35 = ((*(uint32_t*)UnBox((RuntimeObject*)L_37, il2cpp_rgctx_data(method->rgctx_data, 3))));
		return (bool)1;
	}

IL_011f:
	{
		goto IL_0177;
	}

IL_0177:
	{
		goto IL_01aa;
	}

IL_01aa:
	{
		bool L_38 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_38)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_39 = ___1_source;
		Il2CppSharedGenericObject* L_40 = (*(Il2CppSharedGenericObject**)L_39);
		if (L_40)
		{
			goto IL_01db;
		}
	}
	{
		uint32_t* L_41 = ___2_destination;
		il2cpp_codegen_initobj(L_41, sizeof(uint32_t));
		return (bool)1;
	}

IL_01db:
	{
		uint32_t* L_42 = ___2_destination;
		il2cpp_codegen_initobj(L_42, sizeof(uint32_t));
		return (bool)0;
	}
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppSharedGenericObject_TisUInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_m1D70C70B001F828F85C4769D9466AF58C5FE31D9_gshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppSharedGenericObject** ___1_source, uint64_t* ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	uint64_t V_1 = 0;
	TypeConverter_2_tFE7942B61544B13EC61F654A379BB8C5C19E478F* V_2 = NULL;
	Il2CppSharedGenericObject* V_3 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_tFE7942B61544B13EC61F654A379BB8C5C19E478F*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		uint64_t* L_7 = ___2_destination;
		TypeConverter_2_tFE7942B61544B13EC61F654A379BB8C5C19E478F* L_8 = V_2;
		Il2CppSharedGenericObject** L_9 = ___1_source;
		NullCheck(L_8);
		uint64_t L_10;
		L_10 = TypeConverter_2_Invoke_mEA8D3ECFB70460557F24848D00C2A296D047A36F_inline(L_8, L_9, NULL);
		*(uint64_t*)L_7 = L_10;
		return (bool)1;
	}

IL_0034:
	{
		goto IL_0062;
	}

IL_0062:
	{
		Il2CppSharedGenericObject** L_11 = ___1_source;
		uint64_t* L_12 = ___2_destination;
		bool L_13;
		L_13 = PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisUInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_mBB921111FF38E5C99FF61AE3BE80009C2E022239(L_11, L_12, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_13)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppSharedGenericObject** L_14 = ___1_source;
		uint64_t* L_15 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_16;
		L_16 = TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisUInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_m032089056E1895100A9FB554517491D88FD1A89A(L_14, L_15, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_16)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppSharedGenericObject** L_17 = ___1_source;
		uint64_t* L_18 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_19;
		L_19 = TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisUInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_m6048AB2AE3D1B37759345D9381A4288919B5C3D6(L_17, L_18, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_19)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppSharedGenericObject** L_20 = ___1_source;
		Il2CppSharedGenericObject* L_21 = (*(Il2CppSharedGenericObject**)L_20);
		uint64_t* L_22 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_23;
		L_23 = TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisUInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_mB1C7ABF4F0D89B6AFF2CC47A8C61E42904145D05(L_21, L_22, il2cpp_rgctx_method(method->rgctx_data, 10));
		if (!L_23)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		goto IL_00be;
	}

IL_00be:
	{
		Il2CppSharedGenericObject** L_24 = ___1_source;
		Il2CppSharedGenericObject* L_25 = (*(Il2CppSharedGenericObject**)L_24);
		V_3 = L_25;
		Il2CppSharedGenericObject* L_26 = V_3;
		if (!((RuntimeObject*)IsInstSealed((RuntimeObject*)L_26, il2cpp_rgctx_data(method->rgctx_data, 3))))
		{
			goto IL_00ec;
		}
	}
	{
		Il2CppSharedGenericObject* L_27 = V_3;
		V_1 = ((*(uint64_t*)UnBox(((RuntimeObject*)IsInstSealed((RuntimeObject*)L_27, il2cpp_rgctx_data(method->rgctx_data, 3))), il2cpp_rgctx_data(method->rgctx_data, 3))));
		uint64_t* L_28 = ___2_destination;
		uint64_t L_29 = V_1;
		*(uint64_t*)L_28 = L_29;
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_32, NULL);
		NullCheck(L_31);
		bool L_34;
		L_34 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_31, L_33);
		if (!L_34)
		{
			goto IL_011f;
		}
	}
	{
		uint64_t* L_35 = ___2_destination;
		Il2CppSharedGenericObject** L_36 = ___1_source;
		Il2CppSharedGenericObject* L_37 = (*(Il2CppSharedGenericObject**)L_36);
		*(uint64_t*)L_35 = ((*(uint64_t*)UnBox((RuntimeObject*)L_37, il2cpp_rgctx_data(method->rgctx_data, 3))));
		return (bool)1;
	}

IL_011f:
	{
		goto IL_0177;
	}

IL_0177:
	{
		goto IL_01aa;
	}

IL_01aa:
	{
		bool L_38 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_38)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_39 = ___1_source;
		Il2CppSharedGenericObject* L_40 = (*(Il2CppSharedGenericObject**)L_39);
		if (L_40)
		{
			goto IL_01db;
		}
	}
	{
		uint64_t* L_41 = ___2_destination;
		il2cpp_codegen_initobj(L_41, sizeof(uint64_t));
		return (bool)1;
	}

IL_01db:
	{
		uint64_t* L_42 = ___2_destination;
		il2cpp_codegen_initobj(L_42, sizeof(uint64_t));
		return (bool)0;
	}
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppSharedGenericObject_TisVector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_m17F099C840BBDB9D2E8ED069DEDA8B14289864B0_gshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppSharedGenericObject** ___1_source, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 V_1;
	memset((&V_1), 0, sizeof(V_1));
	TypeConverter_2_t4C7D6F1114B9EFC390F0FE6F2860EDC1E7DF3049* V_2 = NULL;
	Il2CppSharedGenericObject* V_3 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_t4C7D6F1114B9EFC390F0FE6F2860EDC1E7DF3049*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* L_7 = ___2_destination;
		TypeConverter_2_t4C7D6F1114B9EFC390F0FE6F2860EDC1E7DF3049* L_8 = V_2;
		Il2CppSharedGenericObject** L_9 = ___1_source;
		NullCheck(L_8);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_10;
		L_10 = TypeConverter_2_Invoke_m49AE9030B92C77BF35406171E80F83866E190EEB_inline(L_8, L_9, NULL);
		*(Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7*)L_7 = L_10;
		return (bool)1;
	}

IL_0034:
	{
		goto IL_0062;
	}

IL_0062:
	{
		Il2CppSharedGenericObject** L_11 = ___1_source;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* L_12 = ___2_destination;
		bool L_13;
		L_13 = PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisVector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_m2CF3D0A8B3D448DC8DC9920EAB7DD7F7294385EF(L_11, L_12, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_13)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppSharedGenericObject** L_14 = ___1_source;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* L_15 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_16;
		L_16 = TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisVector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_mBC9E99471BC4B1516C14CA600EBF62C219CDE927(L_14, L_15, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_16)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppSharedGenericObject** L_17 = ___1_source;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* L_18 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_19;
		L_19 = TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisVector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_mF12E9E30A8C88ED1C3CDC1ABB42D399DB55766B5(L_17, L_18, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_19)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppSharedGenericObject** L_20 = ___1_source;
		Il2CppSharedGenericObject* L_21 = (*(Il2CppSharedGenericObject**)L_20);
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* L_22 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_23;
		L_23 = TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisVector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_mEAC9854D622F8E0FCDE60F2FD1E880F17E1D98BD(L_21, L_22, il2cpp_rgctx_method(method->rgctx_data, 10));
		if (!L_23)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		goto IL_00be;
	}

IL_00be:
	{
		Il2CppSharedGenericObject** L_24 = ___1_source;
		Il2CppSharedGenericObject* L_25 = (*(Il2CppSharedGenericObject**)L_24);
		V_3 = L_25;
		Il2CppSharedGenericObject* L_26 = V_3;
		if (!((RuntimeObject*)IsInstSealed((RuntimeObject*)L_26, il2cpp_rgctx_data(method->rgctx_data, 3))))
		{
			goto IL_00ec;
		}
	}
	{
		Il2CppSharedGenericObject* L_27 = V_3;
		V_1 = ((*(Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7*)UnBox(((RuntimeObject*)IsInstSealed((RuntimeObject*)L_27, il2cpp_rgctx_data(method->rgctx_data, 3))), il2cpp_rgctx_data(method->rgctx_data, 3))));
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* L_28 = ___2_destination;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 L_29 = V_1;
		*(Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7*)L_28 = L_29;
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_32, NULL);
		NullCheck(L_31);
		bool L_34;
		L_34 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_31, L_33);
		if (!L_34)
		{
			goto IL_011f;
		}
	}
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* L_35 = ___2_destination;
		Il2CppSharedGenericObject** L_36 = ___1_source;
		Il2CppSharedGenericObject* L_37 = (*(Il2CppSharedGenericObject**)L_36);
		*(Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7*)L_35 = ((*(Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7*)UnBox((RuntimeObject*)L_37, il2cpp_rgctx_data(method->rgctx_data, 3))));
		return (bool)1;
	}

IL_011f:
	{
		goto IL_0177;
	}

IL_0177:
	{
		goto IL_01aa;
	}

IL_01aa:
	{
		bool L_38 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_38)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_39 = ___1_source;
		Il2CppSharedGenericObject* L_40 = (*(Il2CppSharedGenericObject**)L_39);
		if (L_40)
		{
			goto IL_01db;
		}
	}
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* L_41 = ___2_destination;
		il2cpp_codegen_initobj(L_41, sizeof(Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7));
		return (bool)1;
	}

IL_01db:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* L_42 = ___2_destination;
		il2cpp_codegen_initobj(L_42, sizeof(Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7));
		return (bool)0;
	}
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppSharedGenericObject_TisVector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_m0D02A4A52A982F9078490111E257735038604468_gshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppSharedGenericObject** ___1_source, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 V_1;
	memset((&V_1), 0, sizeof(V_1));
	TypeConverter_2_tA9C93925BAFC7D4786356A2B45762EB2575F3986* V_2 = NULL;
	Il2CppSharedGenericObject* V_3 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_tA9C93925BAFC7D4786356A2B45762EB2575F3986*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_7 = ___2_destination;
		TypeConverter_2_tA9C93925BAFC7D4786356A2B45762EB2575F3986* L_8 = V_2;
		Il2CppSharedGenericObject** L_9 = ___1_source;
		NullCheck(L_8);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_10;
		L_10 = TypeConverter_2_Invoke_m9A7F8EB799C5DB7CC4A9461CF3A66B1A424F189D_inline(L_8, L_9, NULL);
		*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_7 = L_10;
		return (bool)1;
	}

IL_0034:
	{
		goto IL_0062;
	}

IL_0062:
	{
		Il2CppSharedGenericObject** L_11 = ___1_source;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_12 = ___2_destination;
		bool L_13;
		L_13 = PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisVector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_m49EFB846487E3484F55E93EA59F1C8680F01C2A3(L_11, L_12, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_13)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppSharedGenericObject** L_14 = ___1_source;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_15 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_16;
		L_16 = TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisVector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_mA6528517794E3114FFAB96CC8420747CD0F9DCEF(L_14, L_15, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_16)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppSharedGenericObject** L_17 = ___1_source;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_18 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_19;
		L_19 = TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisVector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_m230B481A8A76B8DC7B7A99CDEEF2E6673CE432C8(L_17, L_18, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_19)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppSharedGenericObject** L_20 = ___1_source;
		Il2CppSharedGenericObject* L_21 = (*(Il2CppSharedGenericObject**)L_20);
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_22 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_23;
		L_23 = TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisVector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_m304562AB878726D52E63977FEBBF8A8E1784C510(L_21, L_22, il2cpp_rgctx_method(method->rgctx_data, 10));
		if (!L_23)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		goto IL_00be;
	}

IL_00be:
	{
		Il2CppSharedGenericObject** L_24 = ___1_source;
		Il2CppSharedGenericObject* L_25 = (*(Il2CppSharedGenericObject**)L_24);
		V_3 = L_25;
		Il2CppSharedGenericObject* L_26 = V_3;
		if (!((RuntimeObject*)IsInstSealed((RuntimeObject*)L_26, il2cpp_rgctx_data(method->rgctx_data, 3))))
		{
			goto IL_00ec;
		}
	}
	{
		Il2CppSharedGenericObject* L_27 = V_3;
		V_1 = ((*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)UnBox(((RuntimeObject*)IsInstSealed((RuntimeObject*)L_27, il2cpp_rgctx_data(method->rgctx_data, 3))), il2cpp_rgctx_data(method->rgctx_data, 3))));
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_28 = ___2_destination;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 L_29 = V_1;
		*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_28 = L_29;
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_32, NULL);
		NullCheck(L_31);
		bool L_34;
		L_34 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_31, L_33);
		if (!L_34)
		{
			goto IL_011f;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_35 = ___2_destination;
		Il2CppSharedGenericObject** L_36 = ___1_source;
		Il2CppSharedGenericObject* L_37 = (*(Il2CppSharedGenericObject**)L_36);
		*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_35 = ((*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)UnBox((RuntimeObject*)L_37, il2cpp_rgctx_data(method->rgctx_data, 3))));
		return (bool)1;
	}

IL_011f:
	{
		goto IL_0177;
	}

IL_0177:
	{
		goto IL_01aa;
	}

IL_01aa:
	{
		bool L_38 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_38)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_39 = ___1_source;
		Il2CppSharedGenericObject* L_40 = (*(Il2CppSharedGenericObject**)L_39);
		if (L_40)
		{
			goto IL_01db;
		}
	}
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_41 = ___2_destination;
		il2cpp_codegen_initobj(L_41, sizeof(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2));
		return (bool)1;
	}

IL_01db:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_42 = ___2_destination;
		il2cpp_codegen_initobj(L_42, sizeof(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2));
		return (bool)0;
	}
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppSharedGenericObject_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m233CDE3D0F9E34D78299B8A8CA904CB65AA7AAE0_gshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppSharedGenericObject** ___1_source, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376* ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 V_1;
	memset((&V_1), 0, sizeof(V_1));
	TypeConverter_2_t2257368AB189DB95AF22DD35774E8FEB55C630BB* V_2 = NULL;
	Il2CppSharedGenericObject* V_3 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_t2257368AB189DB95AF22DD35774E8FEB55C630BB*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376* L_7 = ___2_destination;
		TypeConverter_2_t2257368AB189DB95AF22DD35774E8FEB55C630BB* L_8 = V_2;
		Il2CppSharedGenericObject** L_9 = ___1_source;
		NullCheck(L_8);
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 L_10;
		L_10 = TypeConverter_2_Invoke_m88BD1040FEFBC4E99093EA05FF231808CAFDB905_inline(L_8, L_9, NULL);
		*(Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376*)L_7 = L_10;
		return (bool)1;
	}

IL_0034:
	{
		goto IL_0062;
	}

IL_0062:
	{
		Il2CppSharedGenericObject** L_11 = ___1_source;
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376* L_12 = ___2_destination;
		bool L_13;
		L_13 = PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m6157AA92D4D7AAB292C81468B7FFE47C97235CDD(L_11, L_12, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_13)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppSharedGenericObject** L_14 = ___1_source;
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376* L_15 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_16;
		L_16 = TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_mCE9040441F7B72DA914C67E892AB79C88A378C16(L_14, L_15, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_16)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppSharedGenericObject** L_17 = ___1_source;
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376* L_18 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_19;
		L_19 = TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m2AF19A10CED2896DA749F3489173964612DDE1C1(L_17, L_18, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_19)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppSharedGenericObject** L_20 = ___1_source;
		Il2CppSharedGenericObject* L_21 = (*(Il2CppSharedGenericObject**)L_20);
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376* L_22 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_23;
		L_23 = TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_m300E03EBD0D44EC7E31CEDAE2EDDBCD68477B15A(L_21, L_22, il2cpp_rgctx_method(method->rgctx_data, 10));
		if (!L_23)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		goto IL_00be;
	}

IL_00be:
	{
		Il2CppSharedGenericObject** L_24 = ___1_source;
		Il2CppSharedGenericObject* L_25 = (*(Il2CppSharedGenericObject**)L_24);
		V_3 = L_25;
		Il2CppSharedGenericObject* L_26 = V_3;
		if (!((RuntimeObject*)IsInstSealed((RuntimeObject*)L_26, il2cpp_rgctx_data(method->rgctx_data, 3))))
		{
			goto IL_00ec;
		}
	}
	{
		Il2CppSharedGenericObject* L_27 = V_3;
		V_1 = ((*(Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376*)UnBox(((RuntimeObject*)IsInstSealed((RuntimeObject*)L_27, il2cpp_rgctx_data(method->rgctx_data, 3))), il2cpp_rgctx_data(method->rgctx_data, 3))));
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376* L_28 = ___2_destination;
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 L_29 = V_1;
		*(Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376*)L_28 = L_29;
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_32, NULL);
		NullCheck(L_31);
		bool L_34;
		L_34 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_31, L_33);
		if (!L_34)
		{
			goto IL_011f;
		}
	}
	{
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376* L_35 = ___2_destination;
		Il2CppSharedGenericObject** L_36 = ___1_source;
		Il2CppSharedGenericObject* L_37 = (*(Il2CppSharedGenericObject**)L_36);
		*(Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376*)L_35 = ((*(Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376*)UnBox((RuntimeObject*)L_37, il2cpp_rgctx_data(method->rgctx_data, 3))));
		return (bool)1;
	}

IL_011f:
	{
		goto IL_0177;
	}

IL_0177:
	{
		goto IL_01aa;
	}

IL_01aa:
	{
		bool L_38 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_38)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_39 = ___1_source;
		Il2CppSharedGenericObject* L_40 = (*(Il2CppSharedGenericObject**)L_39);
		if (L_40)
		{
			goto IL_01db;
		}
	}
	{
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376* L_41 = ___2_destination;
		il2cpp_codegen_initobj(L_41, sizeof(Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376));
		return (bool)1;
	}

IL_01db:
	{
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376* L_42 = ___2_destination;
		il2cpp_codegen_initobj(L_42, sizeof(Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376));
		return (bool)0;
	}
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppSharedGenericObject_TisIl2CppSharedGenericObject_m9D4D35F37D9C91303721C65E49DFA150732ABF09_gshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppSharedGenericObject** ___1_source, Il2CppSharedGenericObject** ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	Il2CppSharedGenericObject* V_1 = NULL;
	TypeConverter_2_t0525BA89BAB435F8C9F2EEF9023F9BCB7ABE80A1* V_2 = NULL;
	Il2CppSharedGenericObject* V_3 = NULL;
	Il2CppSharedGenericObject** G_B23_0 = NULL;
	Il2CppSharedGenericObject** G_B23_1 = NULL;
	Il2CppSharedGenericObject** G_B21_0 = NULL;
	Il2CppSharedGenericObject** G_B21_1 = NULL;
	Il2CppSharedGenericObject** G_B22_0 = NULL;
	Il2CppSharedGenericObject** G_B22_1 = NULL;
	String_t* G_B24_0 = NULL;
	Il2CppSharedGenericObject** G_B24_1 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_t0525BA89BAB435F8C9F2EEF9023F9BCB7ABE80A1*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		Il2CppSharedGenericObject** L_7 = ___2_destination;
		TypeConverter_2_t0525BA89BAB435F8C9F2EEF9023F9BCB7ABE80A1* L_8 = V_2;
		Il2CppSharedGenericObject** L_9 = ___1_source;
		NullCheck(L_8);
		Il2CppSharedGenericObject* L_10;
		L_10 = TypeConverter_2_Invoke_mF0FFFFF940DA8BB84CBB0B4BD67E875750ADA97C_inline(L_8, L_9, NULL);
		*(Il2CppSharedGenericObject**)L_7 = L_10;
		Il2CppCodeGenWriteBarrier((void**)(Il2CppSharedGenericObject**)L_7, (void*)L_10);
		return (bool)1;
	}

IL_0034:
	{
		bool L_11 = (il2cpp_rgctx_data(method->rgctx_data, 3)) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_11)
		{
			goto IL_0062;
		}
	}
	{
		Il2CppSharedGenericObject** L_12 = ___2_destination;
		Il2CppSharedGenericObject** L_13 = ___1_source;
		Il2CppSharedGenericObject** L_14;
		L_14 = UnsafeUtility_As_TisIl2CppSharedGenericObject_TisIl2CppSharedGenericObject_m7E01BE5B3130A632C43D1F86A8781C30A93D3DCF_inline(L_13, NULL);
		Il2CppSharedGenericObject* L_15 = (*(Il2CppSharedGenericObject**)L_14);
		*(Il2CppSharedGenericObject**)L_12 = L_15;
		Il2CppCodeGenWriteBarrier((void**)(Il2CppSharedGenericObject**)L_12, (void*)L_15);
		return (bool)1;
	}

IL_0062:
	{
		Il2CppSharedGenericObject** L_16 = ___1_source;
		Il2CppSharedGenericObject** L_17 = ___2_destination;
		bool L_18;
		L_18 = PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_TisIl2CppSharedGenericObject_m8343A93DAE3091C3CD02BAC3040AB4BB095DB4ED(L_16, L_17, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_18)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppSharedGenericObject** L_19 = ___1_source;
		Il2CppSharedGenericObject** L_20 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_21;
		L_21 = TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_TisIl2CppSharedGenericObject_m034C149F56406F6438D59B3B56CE2DAD125E75D9(L_19, L_20, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_21)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppSharedGenericObject** L_22 = ___1_source;
		Il2CppSharedGenericObject** L_23 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_24;
		L_24 = TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_TisIl2CppSharedGenericObject_mDAB6678DE2D56B194CD5E28F0EE09524A56EB17C(L_22, L_23, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_24)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppSharedGenericObject** L_25 = ___1_source;
		Il2CppSharedGenericObject* L_26 = (*(Il2CppSharedGenericObject**)L_25);
		Il2CppSharedGenericObject** L_27 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_28;
		L_28 = TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_TisIl2CppSharedGenericObject_m69CA52F1857A6F0CC726661F95B30610A2A5A056(L_26, L_27, il2cpp_rgctx_method(method->rgctx_data, 10));
		if (!L_28)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		goto IL_00be;
	}

IL_00be:
	{
		Il2CppSharedGenericObject** L_29 = ___1_source;
		Il2CppSharedGenericObject* L_30 = (*(Il2CppSharedGenericObject**)L_29);
		V_3 = L_30;
		Il2CppSharedGenericObject* L_31 = V_3;
		if (!((Il2CppSharedGenericObject*)IsInst((RuntimeObject*)L_31, il2cpp_rgctx_data(method->rgctx_data, 3))))
		{
			goto IL_00ec;
		}
	}
	{
		Il2CppSharedGenericObject* L_32 = V_3;
		V_1 = ((Il2CppSharedGenericObject*)IsInst((RuntimeObject*)L_32, il2cpp_rgctx_data(method->rgctx_data, 3)));
		Il2CppSharedGenericObject** L_33 = ___2_destination;
		Il2CppSharedGenericObject* L_34 = V_1;
		*(Il2CppSharedGenericObject**)L_33 = L_34;
		Il2CppCodeGenWriteBarrier((void**)(Il2CppSharedGenericObject**)L_33, (void*)L_34);
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_35 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_36;
		L_36 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_35, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_37 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_38;
		L_38 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_37, NULL);
		NullCheck(L_36);
		bool L_39;
		L_39 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_36, L_38);
		if (!L_39)
		{
			goto IL_011f;
		}
	}
	{
		Il2CppSharedGenericObject** L_40 = ___2_destination;
		Il2CppSharedGenericObject** L_41 = ___1_source;
		Il2CppSharedGenericObject* L_42 = (*(Il2CppSharedGenericObject**)L_41);
		*(Il2CppSharedGenericObject**)L_40 = ((Il2CppSharedGenericObject*)Castclass((RuntimeObject*)L_42, il2cpp_rgctx_data(method->rgctx_data, 3)));
		Il2CppCodeGenWriteBarrier((void**)(Il2CppSharedGenericObject**)L_40, (void*)((Il2CppSharedGenericObject*)Castclass((RuntimeObject*)L_42, il2cpp_rgctx_data(method->rgctx_data, 3))));
		return (bool)1;
	}

IL_011f:
	{
		bool L_43 = (String_t_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 3));
		if (!L_43)
		{
			goto IL_0177;
		}
	}
	{
		Il2CppSharedGenericObject** L_44 = ___2_destination;
		Il2CppSharedGenericObject** L_45 = ___1_source;
		il2cpp_codegen_initobj((&V_3), sizeof(Il2CppSharedGenericObject*));
		Il2CppSharedGenericObject* L_46 = V_3;
		if (L_46)
		{
			G_B23_0 = L_45;
			G_B23_1 = L_44;
			goto IL_0160;
		}
		G_B21_0 = L_45;
		G_B21_1 = L_44;
	}
	{
		Il2CppSharedGenericObject* L_47 = (*(Il2CppSharedGenericObject**)G_B21_0);
		V_3 = L_47;
		Il2CppSharedGenericObject* L_48 = V_3;
		if (L_48)
		{
			G_B23_0 = (&V_3);
			G_B23_1 = G_B21_1;
			goto IL_0160;
		}
		G_B22_0 = (&V_3);
		G_B22_1 = G_B21_1;
	}
	{
		G_B24_0 = ((String_t*)(NULL));
		G_B24_1 = G_B22_1;
		goto IL_016b;
	}

IL_0160:
	{
		NullCheck((RuntimeObject*)(*G_B23_0));
		String_t* L_49;
		L_49 = VirtualFuncInvoker0< String_t* >::Invoke(3, (RuntimeObject*)(*G_B23_0));
		G_B24_0 = L_49;
		G_B24_1 = G_B23_1;
	}

IL_016b:
	{
		*(Il2CppSharedGenericObject**)G_B24_1 = ((Il2CppSharedGenericObject*)Castclass((RuntimeObject*)G_B24_0, il2cpp_rgctx_data(method->rgctx_data, 3)));
		Il2CppCodeGenWriteBarrier((void**)(Il2CppSharedGenericObject**)G_B24_1, (void*)((Il2CppSharedGenericObject*)Castclass((RuntimeObject*)G_B24_0, il2cpp_rgctx_data(method->rgctx_data, 3))));
		return (bool)1;
	}

IL_0177:
	{
		bool L_50 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 3));
		if (!L_50)
		{
			goto IL_01aa;
		}
	}
	{
		Il2CppSharedGenericObject** L_51 = ___2_destination;
		Il2CppSharedGenericObject** L_52 = ___1_source;
		Il2CppSharedGenericObject* L_53 = (*(Il2CppSharedGenericObject**)L_52);
		*(Il2CppSharedGenericObject**)L_51 = ((Il2CppSharedGenericObject*)Castclass((RuntimeObject*)L_53, il2cpp_rgctx_data(method->rgctx_data, 3)));
		Il2CppCodeGenWriteBarrier((void**)(Il2CppSharedGenericObject**)L_51, (void*)((Il2CppSharedGenericObject*)Castclass((RuntimeObject*)L_53, il2cpp_rgctx_data(method->rgctx_data, 3))));
		return (bool)1;
	}

IL_01aa:
	{
		bool L_54 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_54)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_55 = ___1_source;
		Il2CppSharedGenericObject* L_56 = (*(Il2CppSharedGenericObject**)L_55);
		if (L_56)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_57 = ___2_destination;
		il2cpp_codegen_initobj(L_57, sizeof(Il2CppSharedGenericObject*));
		return (bool)1;
	}

IL_01db:
	{
		Il2CppSharedGenericObject** L_58 = ___2_destination;
		il2cpp_codegen_initobj(L_58, sizeof(Il2CppSharedGenericObject*));
		return (bool)0;
	}
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppSharedGenericObject_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_m865C2F50EB52EC530ADE06F56C3F3BB90935FA6F_gshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppSharedGenericObject** ___1_source, int32_t* ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	int32_t V_1 = 0;
	TypeConverter_2_t81D4A80534427AD7BC452191F15131144F2FF763* V_2 = NULL;
	Il2CppSharedGenericObject* V_3 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_t81D4A80534427AD7BC452191F15131144F2FF763*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		int32_t* L_7 = ___2_destination;
		TypeConverter_2_t81D4A80534427AD7BC452191F15131144F2FF763* L_8 = V_2;
		Il2CppSharedGenericObject** L_9 = ___1_source;
		NullCheck(L_8);
		int32_t L_10;
		L_10 = TypeConverter_2_Invoke_m7765922B627FE0A4912228208A85C752498BDC44_inline(L_8, L_9, NULL);
		*(int32_t*)L_7 = L_10;
		return (bool)1;
	}

IL_0034:
	{
		goto IL_0062;
	}

IL_0062:
	{
		Il2CppSharedGenericObject** L_11 = ___1_source;
		int32_t* L_12 = ___2_destination;
		bool L_13;
		L_13 = PrimitivesConverters_TryConvertPrimitiveOrString_TisIl2CppSharedGenericObject_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_m316683D4F266C24D4C1495CD004BDC50F3AE3827(L_11, L_12, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_13)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppSharedGenericObject** L_14 = ___1_source;
		int32_t* L_15 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_16;
		L_16 = TypeConversion_TryConvertNullable_TisIl2CppSharedGenericObject_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_m42DE9E0B9A4D56213CE7044948F570C5E27289F2(L_14, L_15, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_16)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppSharedGenericObject** L_17 = ___1_source;
		int32_t* L_18 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_19;
		L_19 = TypeConversion_TryConvertEnum_TisIl2CppSharedGenericObject_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_mD67DFE8D393E6CC55EB59A3C824DD7F8FEBDA6C9(L_17, L_18, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_19)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppSharedGenericObject** L_20 = ___1_source;
		Il2CppSharedGenericObject* L_21 = (*(Il2CppSharedGenericObject**)L_20);
		int32_t* L_22 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_23;
		L_23 = TypeConversion_TryConvertToUnityEngineObject_TisIl2CppSharedGenericObject_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_m0BDE3F76A27AF8EE49D883FDA385E6DC4AED439D(L_21, L_22, il2cpp_rgctx_method(method->rgctx_data, 10));
		if (!L_23)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		goto IL_00be;
	}

IL_00be:
	{
		Il2CppSharedGenericObject** L_24 = ___1_source;
		Il2CppSharedGenericObject* L_25 = (*(Il2CppSharedGenericObject**)L_24);
		V_3 = L_25;
		Il2CppSharedGenericObject* L_26 = V_3;
		if (!((RuntimeObject*)IsInstSealed((RuntimeObject*)L_26, il2cpp_rgctx_data(method->rgctx_data, 3))))
		{
			goto IL_00ec;
		}
	}
	{
		Il2CppSharedGenericObject* L_27 = V_3;
		V_1 = ((*(int32_t*)UnBox(((RuntimeObject*)IsInstSealed((RuntimeObject*)L_27, il2cpp_rgctx_data(method->rgctx_data, 3))), il2cpp_rgctx_data(method->rgctx_data, 3))));
		int32_t* L_28 = ___2_destination;
		int32_t L_29 = V_1;
		*(int32_t*)L_28 = L_29;
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_30 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_31;
		L_31 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_30, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_32 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_33;
		L_33 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_32, NULL);
		NullCheck(L_31);
		bool L_34;
		L_34 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_31, L_33);
		if (!L_34)
		{
			goto IL_011f;
		}
	}
	{
		int32_t* L_35 = ___2_destination;
		Il2CppSharedGenericObject** L_36 = ___1_source;
		Il2CppSharedGenericObject* L_37 = (*(Il2CppSharedGenericObject**)L_36);
		*(int32_t*)L_35 = ((*(int32_t*)UnBox((RuntimeObject*)L_37, il2cpp_rgctx_data(method->rgctx_data, 3))));
		return (bool)1;
	}

IL_011f:
	{
		goto IL_0177;
	}

IL_0177:
	{
		goto IL_01aa;
	}

IL_01aa:
	{
		bool L_38 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_38)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppSharedGenericObject** L_39 = ___1_source;
		Il2CppSharedGenericObject* L_40 = (*(Il2CppSharedGenericObject**)L_39);
		if (L_40)
		{
			goto IL_01db;
		}
	}
	{
		int32_t* L_41 = ___2_destination;
		il2cpp_codegen_initobj(L_41, sizeof(int32_t));
		return (bool)1;
	}

IL_01db:
	{
		int32_t* L_42 = ___2_destination;
		il2cpp_codegen_initobj(L_42, sizeof(int32_t));
		return (bool)0;
	}
}
// Method Definition Index: 73544
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvert_TisIl2CppFullySharedGenericAny_TisIl2CppFullySharedGenericAny_mC18DF87EC56E149F05CE5A957357981A256F363B_fshared (ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* ___0_registry, Il2CppFullySharedGenericAny* ___1_source, Il2CppFullySharedGenericAny* ___2_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	const uint32_t SizeOf_TDestination_t3724BA210FF8343181B34EA785BF292C5A551EDB = il2cpp_codegen_sizeof(il2cpp_rgctx_data(method->rgctx_data, 3));
	const uint32_t SizeOf_TSource_t34488007A4E6B11D4ECC189FFD259B6F93CB916A = il2cpp_codegen_sizeof(il2cpp_rgctx_data(method->rgctx_data, 1));
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	void* L_59 = alloca(Il2CppFakeBoxBuffer::SizeNeededFor(il2cpp_rgctx_data(method->rgctx_data, 1)));
	const Il2CppFullySharedGenericAny L_26 = alloca(SizeOf_TSource_t34488007A4E6B11D4ECC189FFD259B6F93CB916A);
	const Il2CppFullySharedGenericAny L_33 = L_26;
	const Il2CppFullySharedGenericAny L_36 = L_26;
	const Il2CppFullySharedGenericAny L_49 = L_26;
	const Il2CppFullySharedGenericAny L_54 = L_26;
	const Il2CppFullySharedGenericAny L_56 = L_26;
	const Il2CppFullySharedGenericAny L_69 = L_26;
	const Il2CppFullySharedGenericAny L_73 = L_26;
	const Il2CppFullySharedGenericAny L_34 = alloca(SizeOf_TSource_t34488007A4E6B11D4ECC189FFD259B6F93CB916A);
	const Il2CppFullySharedGenericAny L_57 = L_34;
	const Il2CppFullySharedGenericAny L_10 = alloca(SizeOf_TDestination_t3724BA210FF8343181B34EA785BF292C5A551EDB);
	const Il2CppFullySharedGenericAny L_15 = L_10;
	const Il2CppFullySharedGenericAny L_38 = L_10;
	const Il2CppFullySharedGenericAny L_50 = L_10;
	const Il2CppFullySharedGenericAny L_64 = L_10;
	const Il2CppFullySharedGenericAny L_70 = L_10;
	const Il2CppFullySharedGenericAny L_41 = alloca(SizeOf_TDestination_t3724BA210FF8343181B34EA785BF292C5A551EDB);
	//<source_info:<no-source>:1>
	Delegate_t* V_0 = NULL;
	Il2CppFullySharedGenericAny V_1 = alloca(SizeOf_TDestination_t3724BA210FF8343181B34EA785BF292C5A551EDB);
	memset(V_1, 0, SizeOf_TDestination_t3724BA210FF8343181B34EA785BF292C5A551EDB);
	TypeConverter_2_tA6276E0BDB8DB9E3B10AF0C31301ACC071589845* V_2 = NULL;
	Il2CppFullySharedGenericAny V_3 = alloca(SizeOf_TSource_t34488007A4E6B11D4ECC189FFD259B6F93CB916A);
	memset(V_3, 0, SizeOf_TSource_t34488007A4E6B11D4ECC189FFD259B6F93CB916A);
	Il2CppFullySharedGenericAny* G_B23_0 = NULL;
	Il2CppFullySharedGenericAny* G_B23_1 = NULL;
	Il2CppFullySharedGenericAny* G_B21_0 = NULL;
	Il2CppFullySharedGenericAny* G_B21_1 = NULL;
	Il2CppFullySharedGenericAny G_B22_0 = alloca(SizeOf_TSource_t34488007A4E6B11D4ECC189FFD259B6F93CB916A);
	memset(G_B22_0, 0, SizeOf_TSource_t34488007A4E6B11D4ECC189FFD259B6F93CB916A);
	Il2CppFullySharedGenericAny* G_B22_1 = NULL;
	String_t* G_B24_0 = NULL;
	Il2CppFullySharedGenericAny* G_B24_1 = NULL;
	{
		ConversionRegistry_tBB92E13DAE967B31A341845C05EC88A2603E6426* L_0 = ___0_registry;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_3 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		Type_t* L_4;
		L_4 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_3, NULL);
		bool L_5;
		L_5 = ConversionRegistry_TryGetConverter_mA5C88244D7C991C10AE5940EA5829BC20B3781CD(L_0, L_2, L_4, (&V_0), NULL);
		if (!L_5)
		{
			goto IL_0034;
		}
	}
	{
		Delegate_t* L_6 = V_0;
		V_2 = ((TypeConverter_2_tA6276E0BDB8DB9E3B10AF0C31301ACC071589845*)Castclass((RuntimeObject*)L_6, il2cpp_rgctx_data(method->rgctx_data, 4)));
		Il2CppFullySharedGenericAny* L_7 = ___2_destination;
		TypeConverter_2_tA6276E0BDB8DB9E3B10AF0C31301ACC071589845* L_8 = V_2;
		Il2CppFullySharedGenericAny* L_9 = ___1_source;
		NullCheck(L_8);
		InvokerActionInvoker2< Il2CppFullySharedGenericAny*, Il2CppFullySharedGenericAny* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 5)), il2cpp_rgctx_method(method->rgctx_data, 5), L_8, L_9, (Il2CppFullySharedGenericAny*)L_10);
		il2cpp_codegen_memcpy((Il2CppFullySharedGenericAny*)L_7, L_10, SizeOf_TDestination_t3724BA210FF8343181B34EA785BF292C5A551EDB);
		Il2CppCodeGenWriteBarrierForClass(il2cpp_rgctx_data(method->rgctx_data, 3), (void**)(Il2CppFullySharedGenericAny*)L_7, (void*)L_10);
		return (bool)1;
	}

IL_0034:
	{
		bool L_11 = (il2cpp_rgctx_data(method->rgctx_data, 3)) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_11)
		{
			goto IL_0062;
		}
	}
	{
		Il2CppFullySharedGenericAny* L_12 = ___2_destination;
		Il2CppFullySharedGenericAny* L_13 = ___1_source;
		Il2CppFullySharedGenericAny* L_14;
		L_14 = ((  Il2CppFullySharedGenericAny* (*) (Il2CppFullySharedGenericAny*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 6)))(L_13, il2cpp_rgctx_method(method->rgctx_data, 6));
		il2cpp_codegen_memcpy(L_15, L_14, SizeOf_TDestination_t3724BA210FF8343181B34EA785BF292C5A551EDB);
		il2cpp_codegen_memcpy((Il2CppFullySharedGenericAny*)L_12, L_15, SizeOf_TDestination_t3724BA210FF8343181B34EA785BF292C5A551EDB);
		Il2CppCodeGenWriteBarrierForClass(il2cpp_rgctx_data(method->rgctx_data, 3), (void**)(Il2CppFullySharedGenericAny*)L_12, (void*)L_15);
		return (bool)1;
	}

IL_0062:
	{
		Il2CppFullySharedGenericAny* L_16 = ___1_source;
		Il2CppFullySharedGenericAny* L_17 = ___2_destination;
		bool L_18;
		L_18 = ((  bool (*) (Il2CppFullySharedGenericAny*, Il2CppFullySharedGenericAny*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 7)))(L_16, L_17, il2cpp_rgctx_method(method->rgctx_data, 7));
		if (!L_18)
		{
			goto IL_006d;
		}
	}
	{
		return (bool)1;
	}

IL_006d:
	{
		Il2CppFullySharedGenericAny* L_19 = ___1_source;
		Il2CppFullySharedGenericAny* L_20 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_21;
		L_21 = ((  bool (*) (Il2CppFullySharedGenericAny*, Il2CppFullySharedGenericAny*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 8)))(L_19, L_20, il2cpp_rgctx_method(method->rgctx_data, 8));
		if (!L_21)
		{
			goto IL_0078;
		}
	}
	{
		return (bool)1;
	}

IL_0078:
	{
		Il2CppFullySharedGenericAny* L_22 = ___1_source;
		Il2CppFullySharedGenericAny* L_23 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_24;
		L_24 = ((  bool (*) (Il2CppFullySharedGenericAny*, Il2CppFullySharedGenericAny*, const RuntimeMethod*))il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 9)))(L_22, L_23, il2cpp_rgctx_method(method->rgctx_data, 9));
		if (!L_24)
		{
			goto IL_0083;
		}
	}
	{
		return (bool)1;
	}

IL_0083:
	{
		Il2CppFullySharedGenericAny* L_25 = ___1_source;
		il2cpp_codegen_memcpy(L_26, L_25, SizeOf_TSource_t34488007A4E6B11D4ECC189FFD259B6F93CB916A);
		Il2CppFullySharedGenericAny* L_27 = ___2_destination;
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_28;
		L_28 = InvokerFuncInvoker2< bool, Il2CppFullySharedGenericAny, Il2CppFullySharedGenericAny* >::Invoke(il2cpp_codegen_get_direct_method_pointer(il2cpp_rgctx_method(method->rgctx_data, 10)), il2cpp_rgctx_method(method->rgctx_data, 10), NULL, (il2cpp_codegen_class_is_value_type(il2cpp_rgctx_data(method->rgctx_data, 1)) ? L_26: *(void**)L_26), L_27);
		if (!L_28)
		{
			goto IL_0093;
		}
	}
	{
		return (bool)1;
	}

IL_0093:
	{
		bool L_29 = il2cpp_codegen_class_is_value_type(il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_29)
		{
			goto IL_00be;
		}
	}
	{
		bool L_30 = il2cpp_codegen_class_is_value_type(il2cpp_rgctx_data(method->rgctx_data, 3));
		if (!L_30)
		{
			goto IL_00be;
		}
	}
	{
		Il2CppFullySharedGenericAny* L_31 = ___2_destination;
		il2cpp_codegen_initobj(L_31, SizeOf_TDestination_t3724BA210FF8343181B34EA785BF292C5A551EDB);
		return (bool)0;
	}

IL_00be:
	{
		Il2CppFullySharedGenericAny* L_32 = ___1_source;
		il2cpp_codegen_memcpy(L_33, L_32, SizeOf_TSource_t34488007A4E6B11D4ECC189FFD259B6F93CB916A);
		il2cpp_codegen_memcpy(V_3, L_33, SizeOf_TSource_t34488007A4E6B11D4ECC189FFD259B6F93CB916A);
		il2cpp_codegen_memcpy(L_34, V_3, SizeOf_TSource_t34488007A4E6B11D4ECC189FFD259B6F93CB916A);
		bool L_35 = il2cpp_codegen_isinst_runtime_check(il2cpp_rgctx_data(method->rgctx_data, 1), il2cpp_rgctx_data(method->rgctx_data, 3), L_34);
		if (!L_35)
		{
			goto IL_00ec;
		}
	}
	{
		il2cpp_codegen_memcpy(L_36, V_3, SizeOf_TSource_t34488007A4E6B11D4ECC189FFD259B6F93CB916A);
		RuntimeObject* L_37 = il2cpp_codegen_isinst_runtime(il2cpp_rgctx_data(method->rgctx_data, 1), il2cpp_rgctx_data(method->rgctx_data, 3), L_36);;
		void* L_39 = UnBox_Any(L_37, il2cpp_rgctx_data(method->rgctx_data, 3), L_38);
		il2cpp_codegen_memcpy(V_1, (((Il2CppFullySharedGenericAny)(Il2CppFullySharedGenericAny*)L_39)), SizeOf_TDestination_t3724BA210FF8343181B34EA785BF292C5A551EDB);
		Il2CppFullySharedGenericAny* L_40 = ___2_destination;
		il2cpp_codegen_memcpy(L_41, V_1, SizeOf_TDestination_t3724BA210FF8343181B34EA785BF292C5A551EDB);
		il2cpp_codegen_memcpy((Il2CppFullySharedGenericAny*)L_40, L_41, SizeOf_TDestination_t3724BA210FF8343181B34EA785BF292C5A551EDB);
		Il2CppCodeGenWriteBarrierForClass(il2cpp_rgctx_data(method->rgctx_data, 3), (void**)(Il2CppFullySharedGenericAny*)L_40, (void*)L_41);
		return (bool)1;
	}

IL_00ec:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_42 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_43;
		L_43 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_42, NULL);
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_44 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		Type_t* L_45;
		L_45 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_44, NULL);
		NullCheck(L_43);
		bool L_46;
		L_46 = VirtualFuncInvoker1< bool, Type_t* >::Invoke(22, L_43, L_45);
		if (!L_46)
		{
			goto IL_011f;
		}
	}
	{
		Il2CppFullySharedGenericAny* L_47 = ___2_destination;
		Il2CppFullySharedGenericAny* L_48 = ___1_source;
		il2cpp_codegen_memcpy(L_49, L_48, SizeOf_TSource_t34488007A4E6B11D4ECC189FFD259B6F93CB916A);
		il2cpp_codegen_box_unbox(L_49, L_50, SizeOf_TDestination_t3724BA210FF8343181B34EA785BF292C5A551EDB, il2cpp_rgctx_data(method->rgctx_data, 1), il2cpp_rgctx_data(method->rgctx_data, 3));
		il2cpp_codegen_memcpy((Il2CppFullySharedGenericAny*)L_47, L_50, SizeOf_TDestination_t3724BA210FF8343181B34EA785BF292C5A551EDB);
		Il2CppCodeGenWriteBarrierForClass(il2cpp_rgctx_data(method->rgctx_data, 3), (void**)(Il2CppFullySharedGenericAny*)L_47, (void*)L_50);
		return (bool)1;
	}

IL_011f:
	{
		bool L_51 = (String_t_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 3));
		if (!L_51)
		{
			goto IL_0177;
		}
	}
	{
		Il2CppFullySharedGenericAny* L_52 = ___2_destination;
		Il2CppFullySharedGenericAny* L_53 = ___1_source;
		il2cpp_codegen_initobj((Il2CppFullySharedGenericAny*)V_3, SizeOf_TSource_t34488007A4E6B11D4ECC189FFD259B6F93CB916A);
		il2cpp_codegen_memcpy(L_54, V_3, SizeOf_TSource_t34488007A4E6B11D4ECC189FFD259B6F93CB916A);
		bool L_55 = il2cpp_codegen_would_box_to_non_null(il2cpp_rgctx_data(method->rgctx_data, 1), L_54);
		if (L_55)
		{
			G_B23_0 = ((Il2CppFullySharedGenericAny*)L_53);
			G_B23_1 = ((Il2CppFullySharedGenericAny*)L_52);
			goto IL_0160;
		}
		G_B21_0 = ((Il2CppFullySharedGenericAny*)L_53);
		G_B21_1 = ((Il2CppFullySharedGenericAny*)L_52);
	}
	{
		il2cpp_codegen_memcpy(L_56, G_B21_0, SizeOf_TSource_t34488007A4E6B11D4ECC189FFD259B6F93CB916A);
		il2cpp_codegen_memcpy(V_3, L_56, SizeOf_TSource_t34488007A4E6B11D4ECC189FFD259B6F93CB916A);
		il2cpp_codegen_memcpy(L_57, V_3, SizeOf_TSource_t34488007A4E6B11D4ECC189FFD259B6F93CB916A);
		bool L_58 = il2cpp_codegen_would_box_to_non_null(il2cpp_rgctx_data(method->rgctx_data, 1), L_57);
		if (L_58)
		{
			G_B23_0 = ((Il2CppFullySharedGenericAny*)(Il2CppFullySharedGenericAny*)V_3);
			G_B23_1 = ((Il2CppFullySharedGenericAny*)G_B21_1);
			goto IL_0160;
		}
		il2cpp_codegen_memcpy(G_B22_0, (Il2CppFullySharedGenericAny*)V_3, SizeOf_TSource_t34488007A4E6B11D4ECC189FFD259B6F93CB916A);
		G_B22_1 = ((Il2CppFullySharedGenericAny*)G_B21_1);
	}
	{
		G_B24_0 = ((String_t*)(NULL));
		G_B24_1 = ((Il2CppFullySharedGenericAny*)G_B22_1);
		goto IL_016b;
	}

IL_0160:
	{
		Il2CppConstrainedCallData L_60;
		Il2CppMethodPointer L_61 = il2cpp_codegen_get_runtime_constrained_call_data(il2cpp_rgctx_data(method->rgctx_data, 1), il2cpp_rgctx_method(method->rgctx_data, 11), (void*)G_B23_0, &L_60, L_59);
		typedef String_t* ( *func_L_62)(void*,const RuntimeMethod*);
		String_t* L_63 = ((func_L_62)L_61)(L_60.thisPtr,L_60.method);
		G_B24_0 = L_63;
		G_B24_1 = ((Il2CppFullySharedGenericAny*)G_B23_1);
	}

IL_016b:
	{
		void* L_65 = UnBox_Any(G_B24_0, il2cpp_rgctx_data(method->rgctx_data, 3), L_64);
		il2cpp_codegen_memcpy((Il2CppFullySharedGenericAny*)G_B24_1, (((Il2CppFullySharedGenericAny)(Il2CppFullySharedGenericAny*)L_65)), SizeOf_TDestination_t3724BA210FF8343181B34EA785BF292C5A551EDB);
		Il2CppCodeGenWriteBarrierForClass(il2cpp_rgctx_data(method->rgctx_data, 3), (void**)(Il2CppFullySharedGenericAny*)G_B24_1, (void*)(((Il2CppFullySharedGenericAny)(Il2CppFullySharedGenericAny*)L_65)));
		return (bool)1;
	}

IL_0177:
	{
		bool L_66 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 3));
		if (!L_66)
		{
			goto IL_01aa;
		}
	}
	{
		Il2CppFullySharedGenericAny* L_67 = ___2_destination;
		Il2CppFullySharedGenericAny* L_68 = ___1_source;
		il2cpp_codegen_memcpy(L_69, L_68, SizeOf_TSource_t34488007A4E6B11D4ECC189FFD259B6F93CB916A);
		il2cpp_codegen_box_unbox(L_69, L_70, SizeOf_TDestination_t3724BA210FF8343181B34EA785BF292C5A551EDB, il2cpp_rgctx_data(method->rgctx_data, 1), il2cpp_rgctx_data(method->rgctx_data, 3));
		il2cpp_codegen_memcpy((Il2CppFullySharedGenericAny*)L_67, L_70, SizeOf_TDestination_t3724BA210FF8343181B34EA785BF292C5A551EDB);
		Il2CppCodeGenWriteBarrierForClass(il2cpp_rgctx_data(method->rgctx_data, 3), (void**)(Il2CppFullySharedGenericAny*)L_67, (void*)L_70);
		return (bool)1;
	}

IL_01aa:
	{
		bool L_71 = (RuntimeObject_il2cpp_TypeInfo_var) == (il2cpp_rgctx_data(method->rgctx_data, 1));
		if (!L_71)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppFullySharedGenericAny* L_72 = ___1_source;
		il2cpp_codegen_memcpy(L_73, L_72, SizeOf_TSource_t34488007A4E6B11D4ECC189FFD259B6F93CB916A);
		bool L_74 = il2cpp_codegen_would_box_to_non_null(il2cpp_rgctx_data(method->rgctx_data, 1), L_73);
		if (L_74)
		{
			goto IL_01db;
		}
	}
	{
		Il2CppFullySharedGenericAny* L_75 = ___2_destination;
		il2cpp_codegen_initobj(L_75, SizeOf_TDestination_t3724BA210FF8343181B34EA785BF292C5A551EDB);
		return (bool)1;
	}

IL_01db:
	{
		Il2CppFullySharedGenericAny* L_76 = ___2_destination;
		il2cpp_codegen_initobj(L_76, SizeOf_TDestination_t3724BA210FF8343181B34EA785BF292C5A551EDB);
		return (bool)0;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisKeyValuePair_2_tEB5CFC17B6D8F2A082613AF75FCB091A2A4EB826_mBD90182971034359C2941CC08AB6DEE6B4127F3D_gshared (bool* ___0_source, KeyValuePair_2_tEB5CFC17B6D8F2A082613AF75FCB091A2A4EB826* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		KeyValuePair_2_tEB5CFC17B6D8F2A082613AF75FCB091A2A4EB826* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(KeyValuePair_2_tEB5CFC17B6D8F2A082613AF75FCB091A2A4EB826*)L_0 = ((*(KeyValuePair_2_tEB5CFC17B6D8F2A082613AF75FCB091A2A4EB826*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		Il2CppCodeGenWriteBarrier((void**)&(((KeyValuePair_2_tEB5CFC17B6D8F2A082613AF75FCB091A2A4EB826*)L_0)->___key), (void*)NULL);
		#if IL2CPP_ENABLE_STRICT_WRITE_BARRIERS
		Il2CppCodeGenWriteBarrier((void**)&(((KeyValuePair_2_tEB5CFC17B6D8F2A082613AF75FCB091A2A4EB826*)L_0)->___value), (void*)NULL);
		#endif
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		KeyValuePair_2_tEB5CFC17B6D8F2A082613AF75FCB091A2A4EB826* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(KeyValuePair_2_tEB5CFC17B6D8F2A082613AF75FCB091A2A4EB826));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		KeyValuePair_2_tEB5CFC17B6D8F2A082613AF75FCB091A2A4EB826* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(KeyValuePair_2_tEB5CFC17B6D8F2A082613AF75FCB091A2A4EB826));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleEnum_1_tAFD4AA79F79D19DE23805D46DA67778A70EBBF26_m209EC806F178E2F5BA13D21520B2DF5BF386A5AA_gshared (bool* ___0_source, StyleEnum_1_tAFD4AA79F79D19DE23805D46DA67778A70EBBF26* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleEnum_1_tAFD4AA79F79D19DE23805D46DA67778A70EBBF26* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleEnum_1_tAFD4AA79F79D19DE23805D46DA67778A70EBBF26*)L_0 = ((*(StyleEnum_1_tAFD4AA79F79D19DE23805D46DA67778A70EBBF26*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleEnum_1_tAFD4AA79F79D19DE23805D46DA67778A70EBBF26* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleEnum_1_tAFD4AA79F79D19DE23805D46DA67778A70EBBF26));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleEnum_1_tAFD4AA79F79D19DE23805D46DA67778A70EBBF26* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleEnum_1_tAFD4AA79F79D19DE23805D46DA67778A70EBBF26));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleList_1_t5D2FA4535A553635ADCE6E1E3758E1FA02160E6F_mD3CCBDB6E20A3B1AE1AE3806DB621873EF4DCFC1 (bool* ___0_source, StyleList_1_t5D2FA4535A553635ADCE6E1E3758E1FA02160E6F* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleList_1_t5D2FA4535A553635ADCE6E1E3758E1FA02160E6F* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleList_1_t5D2FA4535A553635ADCE6E1E3758E1FA02160E6F*)L_0 = ((*(StyleList_1_t5D2FA4535A553635ADCE6E1E3758E1FA02160E6F*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		Il2CppCodeGenWriteBarrier((void**)&(((StyleList_1_t5D2FA4535A553635ADCE6E1E3758E1FA02160E6F*)L_0)->___m_Value), (void*)NULL);
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleList_1_t5D2FA4535A553635ADCE6E1E3758E1FA02160E6F* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleList_1_t5D2FA4535A553635ADCE6E1E3758E1FA02160E6F));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleList_1_t5D2FA4535A553635ADCE6E1E3758E1FA02160E6F* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleList_1_t5D2FA4535A553635ADCE6E1E3758E1FA02160E6F));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleList_1_t8C83D4A5BF11A124E8127624CA6DC7ED436CA356_m3095F6A2248ABB5FCFAA24EAE96DBBECAA75D3C2 (bool* ___0_source, StyleList_1_t8C83D4A5BF11A124E8127624CA6DC7ED436CA356* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleList_1_t8C83D4A5BF11A124E8127624CA6DC7ED436CA356* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleList_1_t8C83D4A5BF11A124E8127624CA6DC7ED436CA356*)L_0 = ((*(StyleList_1_t8C83D4A5BF11A124E8127624CA6DC7ED436CA356*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		Il2CppCodeGenWriteBarrier((void**)&(((StyleList_1_t8C83D4A5BF11A124E8127624CA6DC7ED436CA356*)L_0)->___m_Value), (void*)NULL);
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleList_1_t8C83D4A5BF11A124E8127624CA6DC7ED436CA356* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleList_1_t8C83D4A5BF11A124E8127624CA6DC7ED436CA356));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleList_1_t8C83D4A5BF11A124E8127624CA6DC7ED436CA356* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleList_1_t8C83D4A5BF11A124E8127624CA6DC7ED436CA356));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleList_1_tABF3DD9EB70CDF59829924CBA26ACDD1FBDD4C3C_mB09A53EB06223AF967838C19043DBB7C179D1E78 (bool* ___0_source, StyleList_1_tABF3DD9EB70CDF59829924CBA26ACDD1FBDD4C3C* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleList_1_tABF3DD9EB70CDF59829924CBA26ACDD1FBDD4C3C* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleList_1_tABF3DD9EB70CDF59829924CBA26ACDD1FBDD4C3C*)L_0 = ((*(StyleList_1_tABF3DD9EB70CDF59829924CBA26ACDD1FBDD4C3C*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		Il2CppCodeGenWriteBarrier((void**)&(((StyleList_1_tABF3DD9EB70CDF59829924CBA26ACDD1FBDD4C3C*)L_0)->___m_Value), (void*)NULL);
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleList_1_tABF3DD9EB70CDF59829924CBA26ACDD1FBDD4C3C* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleList_1_tABF3DD9EB70CDF59829924CBA26ACDD1FBDD4C3C));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleList_1_tABF3DD9EB70CDF59829924CBA26ACDD1FBDD4C3C* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleList_1_tABF3DD9EB70CDF59829924CBA26ACDD1FBDD4C3C));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleList_1_t15E0FB58274532956EB643D58F1F7B95BED5B7C4_m8C0A61F04AE1E8A6E591BA35D8E8D6F30486CF05 (bool* ___0_source, StyleList_1_t15E0FB58274532956EB643D58F1F7B95BED5B7C4* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleList_1_t15E0FB58274532956EB643D58F1F7B95BED5B7C4* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleList_1_t15E0FB58274532956EB643D58F1F7B95BED5B7C4*)L_0 = ((*(StyleList_1_t15E0FB58274532956EB643D58F1F7B95BED5B7C4*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		Il2CppCodeGenWriteBarrier((void**)&(((StyleList_1_t15E0FB58274532956EB643D58F1F7B95BED5B7C4*)L_0)->___m_Value), (void*)NULL);
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleList_1_t15E0FB58274532956EB643D58F1F7B95BED5B7C4* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleList_1_t15E0FB58274532956EB643D58F1F7B95BED5B7C4));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleList_1_t15E0FB58274532956EB643D58F1F7B95BED5B7C4* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleList_1_t15E0FB58274532956EB643D58F1F7B95BED5B7C4));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisAngle_t0229F612898D65B3CC646C40A32D93D8A33C1DFC_mD15FA195A5589833E9931B3E6CB9825FE72CF295 (bool* ___0_source, Angle_t0229F612898D65B3CC646C40A32D93D8A33C1DFC* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		Angle_t0229F612898D65B3CC646C40A32D93D8A33C1DFC* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(Angle_t0229F612898D65B3CC646C40A32D93D8A33C1DFC*)L_0 = ((*(Angle_t0229F612898D65B3CC646C40A32D93D8A33C1DFC*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		Angle_t0229F612898D65B3CC646C40A32D93D8A33C1DFC* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(Angle_t0229F612898D65B3CC646C40A32D93D8A33C1DFC));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		Angle_t0229F612898D65B3CC646C40A32D93D8A33C1DFC* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(Angle_t0229F612898D65B3CC646C40A32D93D8A33C1DFC));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisBackground_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8_m70E967D22AA00EC867CAADCA2C48C9D161DF43D9 (bool* ___0_source, Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8*)L_0 = ((*(Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		Il2CppCodeGenWriteBarrier((void**)&(((Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8*)L_0)->___m_Texture), (void*)NULL);
		#if IL2CPP_ENABLE_STRICT_WRITE_BARRIERS
		Il2CppCodeGenWriteBarrier((void**)&(((Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8*)L_0)->___m_Sprite), (void*)NULL);
		#endif
		#if IL2CPP_ENABLE_STRICT_WRITE_BARRIERS
		Il2CppCodeGenWriteBarrier((void**)&(((Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8*)L_0)->___m_RenderTexture), (void*)NULL);
		#endif
		#if IL2CPP_ENABLE_STRICT_WRITE_BARRIERS
		Il2CppCodeGenWriteBarrier((void**)&(((Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8*)L_0)->___m_VectorImage), (void*)NULL);
		#endif
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisBackgroundPosition_tF0822B29FC27A67205A9893EBE03D03B799B8B56_m91BA2AD583F398322656D93B6C3E2106085F57AE (bool* ___0_source, BackgroundPosition_tF0822B29FC27A67205A9893EBE03D03B799B8B56* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		BackgroundPosition_tF0822B29FC27A67205A9893EBE03D03B799B8B56* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(BackgroundPosition_tF0822B29FC27A67205A9893EBE03D03B799B8B56*)L_0 = ((*(BackgroundPosition_tF0822B29FC27A67205A9893EBE03D03B799B8B56*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		BackgroundPosition_tF0822B29FC27A67205A9893EBE03D03B799B8B56* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(BackgroundPosition_tF0822B29FC27A67205A9893EBE03D03B799B8B56));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		BackgroundPosition_tF0822B29FC27A67205A9893EBE03D03B799B8B56* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(BackgroundPosition_tF0822B29FC27A67205A9893EBE03D03B799B8B56));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisBackgroundRepeat_t446EC7315DED2C6822F1047B7587C3018BFB277F_m9A83093F825AC54CB0E290646F41AAA6F1A6BA3E (bool* ___0_source, BackgroundRepeat_t446EC7315DED2C6822F1047B7587C3018BFB277F* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		BackgroundRepeat_t446EC7315DED2C6822F1047B7587C3018BFB277F* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(BackgroundRepeat_t446EC7315DED2C6822F1047B7587C3018BFB277F*)L_0 = ((*(BackgroundRepeat_t446EC7315DED2C6822F1047B7587C3018BFB277F*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		BackgroundRepeat_t446EC7315DED2C6822F1047B7587C3018BFB277F* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(BackgroundRepeat_t446EC7315DED2C6822F1047B7587C3018BFB277F));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		BackgroundRepeat_t446EC7315DED2C6822F1047B7587C3018BFB277F* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(BackgroundRepeat_t446EC7315DED2C6822F1047B7587C3018BFB277F));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisBackgroundSize_t809883E2D7BB1D8D85B4C3E1DBE189F187DB25E7_mBE55F1CF5F6414C9499F7C3E309FB497907713EA (bool* ___0_source, BackgroundSize_t809883E2D7BB1D8D85B4C3E1DBE189F187DB25E7* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		BackgroundSize_t809883E2D7BB1D8D85B4C3E1DBE189F187DB25E7* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(BackgroundSize_t809883E2D7BB1D8D85B4C3E1DBE189F187DB25E7*)L_0 = ((*(BackgroundSize_t809883E2D7BB1D8D85B4C3E1DBE189F187DB25E7*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		BackgroundSize_t809883E2D7BB1D8D85B4C3E1DBE189F187DB25E7* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(BackgroundSize_t809883E2D7BB1D8D85B4C3E1DBE189F187DB25E7));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		BackgroundSize_t809883E2D7BB1D8D85B4C3E1DBE189F187DB25E7* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(BackgroundSize_t809883E2D7BB1D8D85B4C3E1DBE189F187DB25E7));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_mE07CFB347A4D8192444A93E103EE61B08309B146 (bool* ___0_source, bool* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		bool* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(bool*)L_0 = ((*(bool*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		bool* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(bool));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		bool* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(bool));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_mE1846F691E62829C8081FFC6911CE12F18AB10D8 (bool* ___0_source, uint8_t* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		uint8_t* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(uint8_t*)L_0 = ((*(uint8_t*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		uint8_t* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(uint8_t));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		uint8_t* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(uint8_t));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisChar_t521A6F19B456D956AF452D926C32709DC03D6B17_mA59CC13141FFCD8697108173DE96D5FF99D0860F (bool* ___0_source, Il2CppChar* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		Il2CppChar* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(Il2CppChar*)L_0 = ((*(Il2CppChar*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		Il2CppChar* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(Il2CppChar));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		Il2CppChar* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(Il2CppChar));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisColor_tD001788D726C3A7F1379BEED0260B9591F440C1F_m0FBC640DF6F074EAD199AFCE2C54EE57A1349DC3 (bool* ___0_source, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(Color_tD001788D726C3A7F1379BEED0260B9591F440C1F*)L_0 = ((*(Color_tD001788D726C3A7F1379BEED0260B9591F440C1F*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(Color_tD001788D726C3A7F1379BEED0260B9591F440C1F));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(Color_tD001788D726C3A7F1379BEED0260B9591F440C1F));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisCursor_t24C3B5095F65B86794C4F7EA168E324DFDA9EE82_mEBDBFE725EFEA915A36B2C58EB26F1DE6D4421D2 (bool* ___0_source, Cursor_t24C3B5095F65B86794C4F7EA168E324DFDA9EE82* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		Cursor_t24C3B5095F65B86794C4F7EA168E324DFDA9EE82* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(Cursor_t24C3B5095F65B86794C4F7EA168E324DFDA9EE82*)L_0 = ((*(Cursor_t24C3B5095F65B86794C4F7EA168E324DFDA9EE82*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		Cursor_t24C3B5095F65B86794C4F7EA168E324DFDA9EE82* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(Cursor_t24C3B5095F65B86794C4F7EA168E324DFDA9EE82));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		Cursor_t24C3B5095F65B86794C4F7EA168E324DFDA9EE82* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(Cursor_t24C3B5095F65B86794C4F7EA168E324DFDA9EE82));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisDateTime_t66193957C73913903DDAD89FEDC46139BCA5802D_m6B07894B2061106BFD818AFD59666FB3A3FEDF5B (bool* ___0_source, DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D*)L_0 = ((*(DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisDouble_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_mD99532FF09593024A58D828F1E9FD72872D59DFA (bool* ___0_source, double* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		double* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(double*)L_0 = ((*(double*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		double* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(double));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		double* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(double));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisEasingFunction_t5197D3B06056326A8B5C96032CDEBD5D3BDCA7A4_m9CBB9BE8241E1C012B4F14C92987C451B55DA717 (bool* ___0_source, EasingFunction_t5197D3B06056326A8B5C96032CDEBD5D3BDCA7A4* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		EasingFunction_t5197D3B06056326A8B5C96032CDEBD5D3BDCA7A4* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(EasingFunction_t5197D3B06056326A8B5C96032CDEBD5D3BDCA7A4*)L_0 = ((*(EasingFunction_t5197D3B06056326A8B5C96032CDEBD5D3BDCA7A4*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		EasingFunction_t5197D3B06056326A8B5C96032CDEBD5D3BDCA7A4* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(EasingFunction_t5197D3B06056326A8B5C96032CDEBD5D3BDCA7A4));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		EasingFunction_t5197D3B06056326A8B5C96032CDEBD5D3BDCA7A4* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(EasingFunction_t5197D3B06056326A8B5C96032CDEBD5D3BDCA7A4));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisFilterFunction_t32E0707BD9D9F770A2A7578985A5C163FC1AAEFF_m04417333C589DB885525C162D907F81FA8EF5D63 (bool* ___0_source, FilterFunction_t32E0707BD9D9F770A2A7578985A5C163FC1AAEFF* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		FilterFunction_t32E0707BD9D9F770A2A7578985A5C163FC1AAEFF* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(FilterFunction_t32E0707BD9D9F770A2A7578985A5C163FC1AAEFF*)L_0 = ((*(FilterFunction_t32E0707BD9D9F770A2A7578985A5C163FC1AAEFF*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		Il2CppCodeGenWriteBarrier((void**)&(((FilterFunction_t32E0707BD9D9F770A2A7578985A5C163FC1AAEFF*)L_0)->___m_CustomDefinition), (void*)NULL);
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		FilterFunction_t32E0707BD9D9F770A2A7578985A5C163FC1AAEFF* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(FilterFunction_t32E0707BD9D9F770A2A7578985A5C163FC1AAEFF));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		FilterFunction_t32E0707BD9D9F770A2A7578985A5C163FC1AAEFF* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(FilterFunction_t32E0707BD9D9F770A2A7578985A5C163FC1AAEFF));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisFontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C_m83226A84F217EA44868E9A5AF7C3796A2D7BC757 (bool* ___0_source, FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C*)L_0 = ((*(FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		Il2CppCodeGenWriteBarrier((void**)&(((FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C*)L_0)->___m_Font), (void*)NULL);
		#if IL2CPP_ENABLE_STRICT_WRITE_BARRIERS
		Il2CppCodeGenWriteBarrier((void**)&(((FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C*)L_0)->___m_FontAsset), (void*)NULL);
		#endif
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisGradientAlphaKey_tF469955E4BBAF1044320D956CD8D990F1A26EAA0_m7D225CB9F8D4C8834084F7C4E9ADBF1880B11DBF (bool* ___0_source, GradientAlphaKey_tF469955E4BBAF1044320D956CD8D990F1A26EAA0* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		GradientAlphaKey_tF469955E4BBAF1044320D956CD8D990F1A26EAA0* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(GradientAlphaKey_tF469955E4BBAF1044320D956CD8D990F1A26EAA0*)L_0 = ((*(GradientAlphaKey_tF469955E4BBAF1044320D956CD8D990F1A26EAA0*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		GradientAlphaKey_tF469955E4BBAF1044320D956CD8D990F1A26EAA0* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(GradientAlphaKey_tF469955E4BBAF1044320D956CD8D990F1A26EAA0));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		GradientAlphaKey_tF469955E4BBAF1044320D956CD8D990F1A26EAA0* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(GradientAlphaKey_tF469955E4BBAF1044320D956CD8D990F1A26EAA0));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisGradientColorKey_tBD03A613338639E3774A10265CC5F3619C13421A_m9F20C8E596FF0EA929ED1D952D3D7755EA7B551A (bool* ___0_source, GradientColorKey_tBD03A613338639E3774A10265CC5F3619C13421A* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		GradientColorKey_tBD03A613338639E3774A10265CC5F3619C13421A* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(GradientColorKey_tBD03A613338639E3774A10265CC5F3619C13421A*)L_0 = ((*(GradientColorKey_tBD03A613338639E3774A10265CC5F3619C13421A*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		GradientColorKey_tBD03A613338639E3774A10265CC5F3619C13421A* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(GradientColorKey_tBD03A613338639E3774A10265CC5F3619C13421A));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		GradientColorKey_tBD03A613338639E3774A10265CC5F3619C13421A* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(GradientColorKey_tBD03A613338639E3774A10265CC5F3619C13421A));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisGuid_t_mED6A13E2E29545782F610554D70B7488228B41B5 (bool* ___0_source, Guid_t* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		Guid_t* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(Guid_t*)L_0 = ((*(Guid_t*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		Guid_t* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(Guid_t));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		Guid_t* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(Guid_t));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisInt16_tB8EF286A9C33492FA6E6D6E67320BE93E794A175_m036CEF6745C7733CC48868524FA99CA3688696CF (bool* ___0_source, int16_t* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		int16_t* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(int16_t*)L_0 = ((*(int16_t*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		int16_t* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(int16_t));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		int16_t* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(int16_t));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisInt32_t680FF22E76F6EFAD4375103CBBFFA0421349384C_m45F12AF92F98FD90FE741E6DEB231D646E0B0902 (bool* ___0_source, int32_t* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		int32_t* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(int32_t*)L_0 = ((*(int32_t*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		int32_t* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(int32_t));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		int32_t* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(int32_t));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisInt64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3_mB4631536E973FDC18AE8D934CDA1983425144A51 (bool* ___0_source, int64_t* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		int64_t* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(int64_t*)L_0 = ((*(int64_t*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		int64_t* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(int64_t));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		int64_t* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(int64_t));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisKeyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0_m9F8041C0563650843457DE3B1D00E4E8F972AF03 (bool* ___0_source, Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0*)L_0 = ((*(Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(Keyframe_tB9C67DCBFE10C0AE9C52CB5C66E944255C9254F0));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisLength_t90BB06D47DD6DB461ED21BD3E3241FAB6C824256_m90EDA7C16DCF43AB358F9CBB040788941BF83CB7 (bool* ___0_source, Length_t90BB06D47DD6DB461ED21BD3E3241FAB6C824256* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		Length_t90BB06D47DD6DB461ED21BD3E3241FAB6C824256* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(Length_t90BB06D47DD6DB461ED21BD3E3241FAB6C824256*)L_0 = ((*(Length_t90BB06D47DD6DB461ED21BD3E3241FAB6C824256*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		Length_t90BB06D47DD6DB461ED21BD3E3241FAB6C824256* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(Length_t90BB06D47DD6DB461ED21BD3E3241FAB6C824256));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		Length_t90BB06D47DD6DB461ED21BD3E3241FAB6C824256* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(Length_t90BB06D47DD6DB461ED21BD3E3241FAB6C824256));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisMaterialDefinition_t25B84AF58B1F4D1990933E5EBCD2DE6989ECB8CD_mD804F65DFCD8EA1B1FC15307D4AFF70BF7FD4109 (bool* ___0_source, MaterialDefinition_t25B84AF58B1F4D1990933E5EBCD2DE6989ECB8CD* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		MaterialDefinition_t25B84AF58B1F4D1990933E5EBCD2DE6989ECB8CD* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(MaterialDefinition_t25B84AF58B1F4D1990933E5EBCD2DE6989ECB8CD*)L_0 = ((*(MaterialDefinition_t25B84AF58B1F4D1990933E5EBCD2DE6989ECB8CD*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		Il2CppCodeGenWriteBarrier((void**)&(((MaterialDefinition_t25B84AF58B1F4D1990933E5EBCD2DE6989ECB8CD*)L_0)->___m_Material), (void*)NULL);
		#if IL2CPP_ENABLE_STRICT_WRITE_BARRIERS
		Il2CppCodeGenWriteBarrier((void**)&(((MaterialDefinition_t25B84AF58B1F4D1990933E5EBCD2DE6989ECB8CD*)L_0)->___propertyValues), (void*)NULL);
		#endif
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		MaterialDefinition_t25B84AF58B1F4D1990933E5EBCD2DE6989ECB8CD* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(MaterialDefinition_t25B84AF58B1F4D1990933E5EBCD2DE6989ECB8CD));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		MaterialDefinition_t25B84AF58B1F4D1990933E5EBCD2DE6989ECB8CD* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(MaterialDefinition_t25B84AF58B1F4D1990933E5EBCD2DE6989ECB8CD));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisRatio_t66C366BD5A2636748B25C00FD6A63F40A09712B3_m87D28608EC9230A1F93ADF20CF502166F2D466C2 (bool* ___0_source, Ratio_t66C366BD5A2636748B25C00FD6A63F40A09712B3* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		Ratio_t66C366BD5A2636748B25C00FD6A63F40A09712B3* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(Ratio_t66C366BD5A2636748B25C00FD6A63F40A09712B3*)L_0 = ((*(Ratio_t66C366BD5A2636748B25C00FD6A63F40A09712B3*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		Ratio_t66C366BD5A2636748B25C00FD6A63F40A09712B3* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(Ratio_t66C366BD5A2636748B25C00FD6A63F40A09712B3));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		Ratio_t66C366BD5A2636748B25C00FD6A63F40A09712B3* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(Ratio_t66C366BD5A2636748B25C00FD6A63F40A09712B3));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisRotate_tE965CA0281A547AB38B881A3416FF97756D3F4D7_m7D5A470E9466D364B4B20696AD4DEEAEE7BE569C (bool* ___0_source, Rotate_tE965CA0281A547AB38B881A3416FF97756D3F4D7* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		Rotate_tE965CA0281A547AB38B881A3416FF97756D3F4D7* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(Rotate_tE965CA0281A547AB38B881A3416FF97756D3F4D7*)L_0 = ((*(Rotate_tE965CA0281A547AB38B881A3416FF97756D3F4D7*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		Rotate_tE965CA0281A547AB38B881A3416FF97756D3F4D7* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(Rotate_tE965CA0281A547AB38B881A3416FF97756D3F4D7));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		Rotate_tE965CA0281A547AB38B881A3416FF97756D3F4D7* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(Rotate_tE965CA0281A547AB38B881A3416FF97756D3F4D7));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisSByte_tFEFFEF5D2FEBF5207950AE6FAC150FC53B668DB5_mA1DD2CD05A6E04C253D3F32FC20BC82111B33EE7 (bool* ___0_source, int8_t* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		int8_t* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(int8_t*)L_0 = ((*(int8_t*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		int8_t* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(int8_t));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		int8_t* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(int8_t));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisScale_t5594C69C1AC9398B57ABF6C4FA0D4E791B7A4DC7_m9C1C33DE5CFA0BE96967A2542D9A713968CCCE5C (bool* ___0_source, Scale_t5594C69C1AC9398B57ABF6C4FA0D4E791B7A4DC7* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		Scale_t5594C69C1AC9398B57ABF6C4FA0D4E791B7A4DC7* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(Scale_t5594C69C1AC9398B57ABF6C4FA0D4E791B7A4DC7*)L_0 = ((*(Scale_t5594C69C1AC9398B57ABF6C4FA0D4E791B7A4DC7*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		Scale_t5594C69C1AC9398B57ABF6C4FA0D4E791B7A4DC7* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(Scale_t5594C69C1AC9398B57ABF6C4FA0D4E791B7A4DC7));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		Scale_t5594C69C1AC9398B57ABF6C4FA0D4E791B7A4DC7* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(Scale_t5594C69C1AC9398B57ABF6C4FA0D4E791B7A4DC7));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisSerializedArrayView_t811E52198172559E69CE9093CCE7C7970D3A46D6_m6DFB8BC58F14F5B20C36907D71E935A715BC0876 (bool* ___0_source, SerializedArrayView_t811E52198172559E69CE9093CCE7C7970D3A46D6* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		SerializedArrayView_t811E52198172559E69CE9093CCE7C7970D3A46D6* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(SerializedArrayView_t811E52198172559E69CE9093CCE7C7970D3A46D6*)L_0 = ((*(SerializedArrayView_t811E52198172559E69CE9093CCE7C7970D3A46D6*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		SerializedArrayView_t811E52198172559E69CE9093CCE7C7970D3A46D6* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(SerializedArrayView_t811E52198172559E69CE9093CCE7C7970D3A46D6));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		SerializedArrayView_t811E52198172559E69CE9093CCE7C7970D3A46D6* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(SerializedArrayView_t811E52198172559E69CE9093CCE7C7970D3A46D6));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisSerializedObjectView_t3371CA1D296BF0161DBD7A002673B96D76927561_m5A8A42D77A6E9CC4E8865C187DD9F0445B98280E (bool* ___0_source, SerializedObjectView_t3371CA1D296BF0161DBD7A002673B96D76927561* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		SerializedObjectView_t3371CA1D296BF0161DBD7A002673B96D76927561* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(SerializedObjectView_t3371CA1D296BF0161DBD7A002673B96D76927561*)L_0 = ((*(SerializedObjectView_t3371CA1D296BF0161DBD7A002673B96D76927561*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		SerializedObjectView_t3371CA1D296BF0161DBD7A002673B96D76927561* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(SerializedObjectView_t3371CA1D296BF0161DBD7A002673B96D76927561));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		SerializedObjectView_t3371CA1D296BF0161DBD7A002673B96D76927561* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(SerializedObjectView_t3371CA1D296BF0161DBD7A002673B96D76927561));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisSerializedValueView_t132982877F69EB6A5B24A9B8EB004A6B80D087DC_mA122BA0604F0683C1AE1A535C8CF2BFF057FCBCA (bool* ___0_source, SerializedValueView_t132982877F69EB6A5B24A9B8EB004A6B80D087DC* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		SerializedValueView_t132982877F69EB6A5B24A9B8EB004A6B80D087DC* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(SerializedValueView_t132982877F69EB6A5B24A9B8EB004A6B80D087DC*)L_0 = ((*(SerializedValueView_t132982877F69EB6A5B24A9B8EB004A6B80D087DC*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		SerializedValueView_t132982877F69EB6A5B24A9B8EB004A6B80D087DC* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(SerializedValueView_t132982877F69EB6A5B24A9B8EB004A6B80D087DC));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		SerializedValueView_t132982877F69EB6A5B24A9B8EB004A6B80D087DC* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(SerializedValueView_t132982877F69EB6A5B24A9B8EB004A6B80D087DC));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisSingle_t4530F2FF86FCB0DC29F35385CA1BD21BE294761C_mE5FA98283A9934C9B0B359A466BA35CFC4ED206A (bool* ___0_source, float* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		float* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(float*)L_0 = ((*(float*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		float* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(float));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		float* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(float));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleBackground_t28A4439F46056BAFA6F4450CD1DE8F333571C97B_m0896101650C7F4E67DD1BF1ACFBED7A9BE6102B5 (bool* ___0_source, StyleBackground_t28A4439F46056BAFA6F4450CD1DE8F333571C97B* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleBackground_t28A4439F46056BAFA6F4450CD1DE8F333571C97B* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleBackground_t28A4439F46056BAFA6F4450CD1DE8F333571C97B*)L_0 = ((*(StyleBackground_t28A4439F46056BAFA6F4450CD1DE8F333571C97B*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		Il2CppCodeGenWriteBarrier((void**)&((&(((StyleBackground_t28A4439F46056BAFA6F4450CD1DE8F333571C97B*)L_0)->___m_Value))->___m_Texture), (void*)NULL);
		#if IL2CPP_ENABLE_STRICT_WRITE_BARRIERS
		Il2CppCodeGenWriteBarrier((void**)&((&(((StyleBackground_t28A4439F46056BAFA6F4450CD1DE8F333571C97B*)L_0)->___m_Value))->___m_Sprite), (void*)NULL);
		#endif
		#if IL2CPP_ENABLE_STRICT_WRITE_BARRIERS
		Il2CppCodeGenWriteBarrier((void**)&((&(((StyleBackground_t28A4439F46056BAFA6F4450CD1DE8F333571C97B*)L_0)->___m_Value))->___m_RenderTexture), (void*)NULL);
		#endif
		#if IL2CPP_ENABLE_STRICT_WRITE_BARRIERS
		Il2CppCodeGenWriteBarrier((void**)&((&(((StyleBackground_t28A4439F46056BAFA6F4450CD1DE8F333571C97B*)L_0)->___m_Value))->___m_VectorImage), (void*)NULL);
		#endif
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleBackground_t28A4439F46056BAFA6F4450CD1DE8F333571C97B* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleBackground_t28A4439F46056BAFA6F4450CD1DE8F333571C97B));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleBackground_t28A4439F46056BAFA6F4450CD1DE8F333571C97B* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleBackground_t28A4439F46056BAFA6F4450CD1DE8F333571C97B));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleBackgroundPosition_t707AF9D66EF808C1B1DE174CAB623D97A653C3F3_m3175D2CEAEA0BD505E907EAF3D8F42BDA5982B28 (bool* ___0_source, StyleBackgroundPosition_t707AF9D66EF808C1B1DE174CAB623D97A653C3F3* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleBackgroundPosition_t707AF9D66EF808C1B1DE174CAB623D97A653C3F3* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleBackgroundPosition_t707AF9D66EF808C1B1DE174CAB623D97A653C3F3*)L_0 = ((*(StyleBackgroundPosition_t707AF9D66EF808C1B1DE174CAB623D97A653C3F3*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleBackgroundPosition_t707AF9D66EF808C1B1DE174CAB623D97A653C3F3* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleBackgroundPosition_t707AF9D66EF808C1B1DE174CAB623D97A653C3F3));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleBackgroundPosition_t707AF9D66EF808C1B1DE174CAB623D97A653C3F3* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleBackgroundPosition_t707AF9D66EF808C1B1DE174CAB623D97A653C3F3));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleBackgroundRepeat_t38B84958D5608FAA86B06F513716444EA06DB866_m3DEA77FA31A607E9BCFCA9AA1F294A5A15823B2A (bool* ___0_source, StyleBackgroundRepeat_t38B84958D5608FAA86B06F513716444EA06DB866* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleBackgroundRepeat_t38B84958D5608FAA86B06F513716444EA06DB866* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleBackgroundRepeat_t38B84958D5608FAA86B06F513716444EA06DB866*)L_0 = ((*(StyleBackgroundRepeat_t38B84958D5608FAA86B06F513716444EA06DB866*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleBackgroundRepeat_t38B84958D5608FAA86B06F513716444EA06DB866* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleBackgroundRepeat_t38B84958D5608FAA86B06F513716444EA06DB866));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleBackgroundRepeat_t38B84958D5608FAA86B06F513716444EA06DB866* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleBackgroundRepeat_t38B84958D5608FAA86B06F513716444EA06DB866));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleBackgroundSize_t0904929E2E236696CEC8DBD4B1082E8313F84008_m7A91AD0549024748382A7695B7B8A515FC02E064 (bool* ___0_source, StyleBackgroundSize_t0904929E2E236696CEC8DBD4B1082E8313F84008* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleBackgroundSize_t0904929E2E236696CEC8DBD4B1082E8313F84008* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleBackgroundSize_t0904929E2E236696CEC8DBD4B1082E8313F84008*)L_0 = ((*(StyleBackgroundSize_t0904929E2E236696CEC8DBD4B1082E8313F84008*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleBackgroundSize_t0904929E2E236696CEC8DBD4B1082E8313F84008* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleBackgroundSize_t0904929E2E236696CEC8DBD4B1082E8313F84008));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleBackgroundSize_t0904929E2E236696CEC8DBD4B1082E8313F84008* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleBackgroundSize_t0904929E2E236696CEC8DBD4B1082E8313F84008));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleColor_tFC32BA34A15742AC48D6AACF8A137A6F71F04910_m4340143D38DD78B8888FE23DAFB1C3F006F12CB1 (bool* ___0_source, StyleColor_tFC32BA34A15742AC48D6AACF8A137A6F71F04910* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleColor_tFC32BA34A15742AC48D6AACF8A137A6F71F04910* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleColor_tFC32BA34A15742AC48D6AACF8A137A6F71F04910*)L_0 = ((*(StyleColor_tFC32BA34A15742AC48D6AACF8A137A6F71F04910*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleColor_tFC32BA34A15742AC48D6AACF8A137A6F71F04910* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleColor_tFC32BA34A15742AC48D6AACF8A137A6F71F04910));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleColor_tFC32BA34A15742AC48D6AACF8A137A6F71F04910* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleColor_tFC32BA34A15742AC48D6AACF8A137A6F71F04910));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleCursor_tE485E9D7E54AC3A3D514CD63313D77F75BD8C610_m1E0ACAD8BA0DC268A499A67C0D7CCFC13EAC0EB3 (bool* ___0_source, StyleCursor_tE485E9D7E54AC3A3D514CD63313D77F75BD8C610* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleCursor_tE485E9D7E54AC3A3D514CD63313D77F75BD8C610* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleCursor_tE485E9D7E54AC3A3D514CD63313D77F75BD8C610*)L_0 = ((*(StyleCursor_tE485E9D7E54AC3A3D514CD63313D77F75BD8C610*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleCursor_tE485E9D7E54AC3A3D514CD63313D77F75BD8C610* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleCursor_tE485E9D7E54AC3A3D514CD63313D77F75BD8C610));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleCursor_tE485E9D7E54AC3A3D514CD63313D77F75BD8C610* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleCursor_tE485E9D7E54AC3A3D514CD63313D77F75BD8C610));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleFloat_t4A100BCCDC275C2302517C5858C9BE9EC43D4841_mB11DA707B7CB4FD39077C7A0B8C4EED8EE80EA6E (bool* ___0_source, StyleFloat_t4A100BCCDC275C2302517C5858C9BE9EC43D4841* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleFloat_t4A100BCCDC275C2302517C5858C9BE9EC43D4841* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleFloat_t4A100BCCDC275C2302517C5858C9BE9EC43D4841*)L_0 = ((*(StyleFloat_t4A100BCCDC275C2302517C5858C9BE9EC43D4841*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleFloat_t4A100BCCDC275C2302517C5858C9BE9EC43D4841* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleFloat_t4A100BCCDC275C2302517C5858C9BE9EC43D4841));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleFloat_t4A100BCCDC275C2302517C5858C9BE9EC43D4841* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleFloat_t4A100BCCDC275C2302517C5858C9BE9EC43D4841));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleFont_t9D8A6F3E224B60FD8BA1522CE8AB0E2E8BE8B77C_mD13BB1DD67E09FFB0889AD2E7BBC94311F875B8B (bool* ___0_source, StyleFont_t9D8A6F3E224B60FD8BA1522CE8AB0E2E8BE8B77C* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleFont_t9D8A6F3E224B60FD8BA1522CE8AB0E2E8BE8B77C* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleFont_t9D8A6F3E224B60FD8BA1522CE8AB0E2E8BE8B77C*)L_0 = ((*(StyleFont_t9D8A6F3E224B60FD8BA1522CE8AB0E2E8BE8B77C*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		Il2CppCodeGenWriteBarrier((void**)&(((StyleFont_t9D8A6F3E224B60FD8BA1522CE8AB0E2E8BE8B77C*)L_0)->___m_Value), (void*)NULL);
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleFont_t9D8A6F3E224B60FD8BA1522CE8AB0E2E8BE8B77C* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleFont_t9D8A6F3E224B60FD8BA1522CE8AB0E2E8BE8B77C));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleFont_t9D8A6F3E224B60FD8BA1522CE8AB0E2E8BE8B77C* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleFont_t9D8A6F3E224B60FD8BA1522CE8AB0E2E8BE8B77C));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleFontDefinition_t0E1130277B322724A677D489018D219F014070F4_m14D3A01889202F9BA8F4013165F8603AF280CA75 (bool* ___0_source, StyleFontDefinition_t0E1130277B322724A677D489018D219F014070F4* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleFontDefinition_t0E1130277B322724A677D489018D219F014070F4* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleFontDefinition_t0E1130277B322724A677D489018D219F014070F4*)L_0 = ((*(StyleFontDefinition_t0E1130277B322724A677D489018D219F014070F4*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		Il2CppCodeGenWriteBarrier((void**)&((&(((StyleFontDefinition_t0E1130277B322724A677D489018D219F014070F4*)L_0)->___m_Value))->___m_Font), (void*)NULL);
		#if IL2CPP_ENABLE_STRICT_WRITE_BARRIERS
		Il2CppCodeGenWriteBarrier((void**)&((&(((StyleFontDefinition_t0E1130277B322724A677D489018D219F014070F4*)L_0)->___m_Value))->___m_FontAsset), (void*)NULL);
		#endif
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleFontDefinition_t0E1130277B322724A677D489018D219F014070F4* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleFontDefinition_t0E1130277B322724A677D489018D219F014070F4));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleFontDefinition_t0E1130277B322724A677D489018D219F014070F4* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleFontDefinition_t0E1130277B322724A677D489018D219F014070F4));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleInt_tDC5B2FE9B1ABA54EEF85A7798F321F40BDC8B25D_m225BE18FBD54589CE04F2DC2649985D8738CF846 (bool* ___0_source, StyleInt_tDC5B2FE9B1ABA54EEF85A7798F321F40BDC8B25D* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleInt_tDC5B2FE9B1ABA54EEF85A7798F321F40BDC8B25D* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleInt_tDC5B2FE9B1ABA54EEF85A7798F321F40BDC8B25D*)L_0 = ((*(StyleInt_tDC5B2FE9B1ABA54EEF85A7798F321F40BDC8B25D*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleInt_tDC5B2FE9B1ABA54EEF85A7798F321F40BDC8B25D* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleInt_tDC5B2FE9B1ABA54EEF85A7798F321F40BDC8B25D));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleInt_tDC5B2FE9B1ABA54EEF85A7798F321F40BDC8B25D* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleInt_tDC5B2FE9B1ABA54EEF85A7798F321F40BDC8B25D));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleLength_tF02B24735FC88BE29BEB36F7A87709CA28AF72D8_m79FF3C0C9D25FB242A5313B89CB851FAC28394BD (bool* ___0_source, StyleLength_tF02B24735FC88BE29BEB36F7A87709CA28AF72D8* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleLength_tF02B24735FC88BE29BEB36F7A87709CA28AF72D8* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleLength_tF02B24735FC88BE29BEB36F7A87709CA28AF72D8*)L_0 = ((*(StyleLength_tF02B24735FC88BE29BEB36F7A87709CA28AF72D8*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleLength_tF02B24735FC88BE29BEB36F7A87709CA28AF72D8* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleLength_tF02B24735FC88BE29BEB36F7A87709CA28AF72D8));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleLength_tF02B24735FC88BE29BEB36F7A87709CA28AF72D8* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleLength_tF02B24735FC88BE29BEB36F7A87709CA28AF72D8));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471_m5EA7194DE19DB3FFC5083D46B847B565E37EC7C3 (bool* ___0_source, StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471*)L_0 = ((*(StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		Il2CppCodeGenWriteBarrier((void**)&((&(((StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471*)L_0)->___m_Value))->___m_Material), (void*)NULL);
		#if IL2CPP_ENABLE_STRICT_WRITE_BARRIERS
		Il2CppCodeGenWriteBarrier((void**)&((&(((StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471*)L_0)->___m_Value))->___propertyValues), (void*)NULL);
		#endif
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF_m9EB8AE13D93223AB4D6A339EEF07AA4FE699C83C (bool* ___0_source, StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF*)L_0 = ((*(StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		Il2CppCodeGenWriteBarrier((void**)&(((StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF*)L_0)->___U3CnameU3Ek__BackingField), (void*)NULL);
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906_m1D3B8020484966C6D28EA612C3A2A052086693DA (bool* ___0_source, StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906*)L_0 = ((*(StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B_m680F8D14E73A22143A6C593AB6D80CD971043F4A (bool* ___0_source, StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B*)L_0 = ((*(StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC_m72875EE0A31387AC4F05C8EDE18B36F3ABD47099 (bool* ___0_source, StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC*)L_0 = ((*(StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A_m2882CA1EA89D5442A579FDF18B395683DE1EC136 (bool* ___0_source, StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A*)L_0 = ((*(StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252_m34F10ED9A76117081F32C6145B2DD2D7EA4A11F1 (bool* ___0_source, StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252*)L_0 = ((*(StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6_m16E5345A7B5C35701E58F6E75BA6B7D719FA662C (bool* ___0_source, StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6*)L_0 = ((*(StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089_m811154DF88E8AF350B84001C82810145A7009D37 (bool* ___0_source, StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089*)L_0 = ((*(StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisStyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5_m0DD32917015DACC9CD76BE232BC48C72DEC0DB11 (bool* ___0_source, StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5*)L_0 = ((*(StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		Il2CppCodeGenWriteBarrier((void**)&(((StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5*)L_0)->___m_Value), (void*)NULL);
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisTextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A_m98B95FF4585B33EF63270F636171EBF152513DEF (bool* ___0_source, TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A*)L_0 = ((*(TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisTextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05_m2D27C8B55E2864959AAE68D09BD88FCB6A394D77 (bool* ___0_source, TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05*)L_0 = ((*(TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisTimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A_m8B4B03D79C4ECB4E4BC5A025F6BD51E8A1ADE190 (bool* ___0_source, TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A*)L_0 = ((*(TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisTimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E_mC67CD7A93E0BE4F24D527D7224323B5FE597B09F (bool* ___0_source, TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E*)L_0 = ((*(TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisTransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502_mEE1D7ED764575FC4810667AADA5A09833CEAD190 (bool* ___0_source, TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502*)L_0 = ((*(TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisTranslate_t494F6E802F8A640D67819C9D26BE62DED1218A8E_mAF1821D729589326295796B618340CE784A9E8F8 (bool* ___0_source, Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E*)L_0 = ((*(Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisUInt16_tF4C148C876015C212FD72652D0B6ED8CC247A455_m0576DA5B55F40888081B8B9873437F44F47B1EF4 (bool* ___0_source, uint16_t* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		uint16_t* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(uint16_t*)L_0 = ((*(uint16_t*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		uint16_t* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(uint16_t));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		uint16_t* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(uint16_t));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisUInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B_mE386E6A9155CD1195EF0F3BC502A19F66C6D36DD (bool* ___0_source, uint32_t* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		uint32_t* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(uint32_t*)L_0 = ((*(uint32_t*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		uint32_t* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(uint32_t));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		uint32_t* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(uint32_t));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisUInt64_t8F12534CC8FC4B5860F2A2CD1EE79D322E7A41AF_m809B2DCF2510AC1C47A4E657D6A11D6F6DD3FE26 (bool* ___0_source, uint64_t* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		uint64_t* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(uint64_t*)L_0 = ((*(uint64_t*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		uint64_t* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(uint64_t));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		uint64_t* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(uint64_t));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisVector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7_m5A57A5AE38AFCD6AE6BC4DC8BB807F1778267D33 (bool* ___0_source, Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7*)L_0 = ((*(Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisVector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2_m3238CD3D4E81BCDF8ABB9D97F89F3FE0CF2B8123 (bool* ___0_source, Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)L_0 = ((*(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisVector3Int_t65CB06F557251D18A37BD71F3655BA836A357376_mA793BEE6C267808C22B24B54351FBED426BE35F0 (bool* ___0_source, Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376*)L_0 = ((*(Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_TisIl2CppSharedGenericObject_m9275A6877C2DCBD5BB74E046CD25D9A17E1227B6_gshared (bool* ___0_source, Il2CppSharedGenericObject** ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		Il2CppSharedGenericObject** L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(Il2CppSharedGenericObject**)L_0 = ((Il2CppSharedGenericObject*)Castclass((RuntimeObject*)L_7, il2cpp_rgctx_data(method->rgctx_data, 1)));
		Il2CppCodeGenWriteBarrier((void**)(Il2CppSharedGenericObject**)L_0, (void*)((Il2CppSharedGenericObject*)Castclass((RuntimeObject*)L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		Il2CppSharedGenericObject** L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(Il2CppSharedGenericObject*));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		Il2CppSharedGenericObject** L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(Il2CppSharedGenericObject*));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_mE982204EBACA46AC4FC629E688BCA429DD1DB026_gshared (bool* ___0_source, int32_t* ___1_destination, const RuntimeMethod* method) 
{
	if (!il2cpp_rgctx_is_initialized(method))
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var);
		il2cpp_rgctx_method_init(method);
	}
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	CHECKED_LOCAL(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
	}
	{
		goto IL_0066;
	}
	try
	{
		int32_t* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		bool* L_3 = ___0_source;
		bool L_4 = (*(bool*)L_3);
		bool L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(int32_t*)L_0 = ((*(int32_t*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		int32_t* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(int32_t));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_0066:
	{
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_10 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 2)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_11;
		L_11 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_10, NULL);
		CHECKED_LOCAL_INIT(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_StaticInit,(TypeConversion_tC95A24AF93E22908A5717FBF24E5089C963863E9_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		bool L_12;
		L_12 = TypeConversion_IsNumericType_m4ED38C1CEAEA27E582D274BA41FCEAA52D779936(L_11, NULL);
		if (!L_12)
		{
			goto IL_008a;
		}
	}
	{
		int32_t* L_13 = ___1_destination;
		bool* L_14 = ___0_source;
		int32_t* L_15;
		L_15 = UnsafeUtility_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_m9AEA7CA3ED58CAAF5CC970EF8B1182B9DC69D464_inline(L_14, NULL);
		int32_t L_16 = (*(int32_t*)L_15);
		*(int32_t*)L_13 = L_16;
		return (bool)1;
	}

IL_008a:
	{
		int32_t* L_17 = ___1_destination;
		il2cpp_codegen_initobj(L_17, sizeof(int32_t));
		return (bool)0;
	}

IL_0093:
	{
		bool L_18 = V_0;
		return L_18;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisKeyValuePair_2_tEB5CFC17B6D8F2A082613AF75FCB091A2A4EB826_mFC7921F0AC417C859ACC08219A35B56D4BC2CB3F_gshared (uint8_t* ___0_source, KeyValuePair_2_tEB5CFC17B6D8F2A082613AF75FCB091A2A4EB826* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		KeyValuePair_2_tEB5CFC17B6D8F2A082613AF75FCB091A2A4EB826* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		uint8_t* L_3 = ___0_source;
		uint8_t L_4 = (*(uint8_t*)L_3);
		uint8_t L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(KeyValuePair_2_tEB5CFC17B6D8F2A082613AF75FCB091A2A4EB826*)L_0 = ((*(KeyValuePair_2_tEB5CFC17B6D8F2A082613AF75FCB091A2A4EB826*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		Il2CppCodeGenWriteBarrier((void**)&(((KeyValuePair_2_tEB5CFC17B6D8F2A082613AF75FCB091A2A4EB826*)L_0)->___key), (void*)NULL);
		#if IL2CPP_ENABLE_STRICT_WRITE_BARRIERS
		Il2CppCodeGenWriteBarrier((void**)&(((KeyValuePair_2_tEB5CFC17B6D8F2A082613AF75FCB091A2A4EB826*)L_0)->___value), (void*)NULL);
		#endif
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		KeyValuePair_2_tEB5CFC17B6D8F2A082613AF75FCB091A2A4EB826* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(KeyValuePair_2_tEB5CFC17B6D8F2A082613AF75FCB091A2A4EB826));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		KeyValuePair_2_tEB5CFC17B6D8F2A082613AF75FCB091A2A4EB826* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(KeyValuePair_2_tEB5CFC17B6D8F2A082613AF75FCB091A2A4EB826));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisStyleEnum_1_tAFD4AA79F79D19DE23805D46DA67778A70EBBF26_m8F4448ADD08A3A8C534253D8DE23099053409EE1_gshared (uint8_t* ___0_source, StyleEnum_1_tAFD4AA79F79D19DE23805D46DA67778A70EBBF26* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleEnum_1_tAFD4AA79F79D19DE23805D46DA67778A70EBBF26* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		uint8_t* L_3 = ___0_source;
		uint8_t L_4 = (*(uint8_t*)L_3);
		uint8_t L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleEnum_1_tAFD4AA79F79D19DE23805D46DA67778A70EBBF26*)L_0 = ((*(StyleEnum_1_tAFD4AA79F79D19DE23805D46DA67778A70EBBF26*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleEnum_1_tAFD4AA79F79D19DE23805D46DA67778A70EBBF26* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleEnum_1_tAFD4AA79F79D19DE23805D46DA67778A70EBBF26));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleEnum_1_tAFD4AA79F79D19DE23805D46DA67778A70EBBF26* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleEnum_1_tAFD4AA79F79D19DE23805D46DA67778A70EBBF26));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisStyleList_1_t5D2FA4535A553635ADCE6E1E3758E1FA02160E6F_m3F560C1A3BEF4122B4E5EF6C1D25C157D3DD994C (uint8_t* ___0_source, StyleList_1_t5D2FA4535A553635ADCE6E1E3758E1FA02160E6F* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleList_1_t5D2FA4535A553635ADCE6E1E3758E1FA02160E6F* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		uint8_t* L_3 = ___0_source;
		uint8_t L_4 = (*(uint8_t*)L_3);
		uint8_t L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleList_1_t5D2FA4535A553635ADCE6E1E3758E1FA02160E6F*)L_0 = ((*(StyleList_1_t5D2FA4535A553635ADCE6E1E3758E1FA02160E6F*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		Il2CppCodeGenWriteBarrier((void**)&(((StyleList_1_t5D2FA4535A553635ADCE6E1E3758E1FA02160E6F*)L_0)->___m_Value), (void*)NULL);
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleList_1_t5D2FA4535A553635ADCE6E1E3758E1FA02160E6F* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleList_1_t5D2FA4535A553635ADCE6E1E3758E1FA02160E6F));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleList_1_t5D2FA4535A553635ADCE6E1E3758E1FA02160E6F* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleList_1_t5D2FA4535A553635ADCE6E1E3758E1FA02160E6F));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisStyleList_1_t8C83D4A5BF11A124E8127624CA6DC7ED436CA356_m68412980AF137FB30D316C2749EAE9CE958802E6 (uint8_t* ___0_source, StyleList_1_t8C83D4A5BF11A124E8127624CA6DC7ED436CA356* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleList_1_t8C83D4A5BF11A124E8127624CA6DC7ED436CA356* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		uint8_t* L_3 = ___0_source;
		uint8_t L_4 = (*(uint8_t*)L_3);
		uint8_t L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleList_1_t8C83D4A5BF11A124E8127624CA6DC7ED436CA356*)L_0 = ((*(StyleList_1_t8C83D4A5BF11A124E8127624CA6DC7ED436CA356*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		Il2CppCodeGenWriteBarrier((void**)&(((StyleList_1_t8C83D4A5BF11A124E8127624CA6DC7ED436CA356*)L_0)->___m_Value), (void*)NULL);
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleList_1_t8C83D4A5BF11A124E8127624CA6DC7ED436CA356* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleList_1_t8C83D4A5BF11A124E8127624CA6DC7ED436CA356));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleList_1_t8C83D4A5BF11A124E8127624CA6DC7ED436CA356* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleList_1_t8C83D4A5BF11A124E8127624CA6DC7ED436CA356));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisStyleList_1_tABF3DD9EB70CDF59829924CBA26ACDD1FBDD4C3C_m66E195ED8F0A5E76272E900479D7C328000430B3 (uint8_t* ___0_source, StyleList_1_tABF3DD9EB70CDF59829924CBA26ACDD1FBDD4C3C* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleList_1_tABF3DD9EB70CDF59829924CBA26ACDD1FBDD4C3C* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		uint8_t* L_3 = ___0_source;
		uint8_t L_4 = (*(uint8_t*)L_3);
		uint8_t L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleList_1_tABF3DD9EB70CDF59829924CBA26ACDD1FBDD4C3C*)L_0 = ((*(StyleList_1_tABF3DD9EB70CDF59829924CBA26ACDD1FBDD4C3C*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		Il2CppCodeGenWriteBarrier((void**)&(((StyleList_1_tABF3DD9EB70CDF59829924CBA26ACDD1FBDD4C3C*)L_0)->___m_Value), (void*)NULL);
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleList_1_tABF3DD9EB70CDF59829924CBA26ACDD1FBDD4C3C* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleList_1_tABF3DD9EB70CDF59829924CBA26ACDD1FBDD4C3C));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleList_1_tABF3DD9EB70CDF59829924CBA26ACDD1FBDD4C3C* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleList_1_tABF3DD9EB70CDF59829924CBA26ACDD1FBDD4C3C));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisStyleList_1_t15E0FB58274532956EB643D58F1F7B95BED5B7C4_mF1610026026114EA9980D5646D7FF26212D172DD (uint8_t* ___0_source, StyleList_1_t15E0FB58274532956EB643D58F1F7B95BED5B7C4* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		StyleList_1_t15E0FB58274532956EB643D58F1F7B95BED5B7C4* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		uint8_t* L_3 = ___0_source;
		uint8_t L_4 = (*(uint8_t*)L_3);
		uint8_t L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(StyleList_1_t15E0FB58274532956EB643D58F1F7B95BED5B7C4*)L_0 = ((*(StyleList_1_t15E0FB58274532956EB643D58F1F7B95BED5B7C4*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		Il2CppCodeGenWriteBarrier((void**)&(((StyleList_1_t15E0FB58274532956EB643D58F1F7B95BED5B7C4*)L_0)->___m_Value), (void*)NULL);
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		StyleList_1_t15E0FB58274532956EB643D58F1F7B95BED5B7C4* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(StyleList_1_t15E0FB58274532956EB643D58F1F7B95BED5B7C4));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		StyleList_1_t15E0FB58274532956EB643D58F1F7B95BED5B7C4* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(StyleList_1_t15E0FB58274532956EB643D58F1F7B95BED5B7C4));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisAngle_t0229F612898D65B3CC646C40A32D93D8A33C1DFC_m71330218C2FF3CCFF71E4FE2F75FE427662AFCC7 (uint8_t* ___0_source, Angle_t0229F612898D65B3CC646C40A32D93D8A33C1DFC* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		Angle_t0229F612898D65B3CC646C40A32D93D8A33C1DFC* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		uint8_t* L_3 = ___0_source;
		uint8_t L_4 = (*(uint8_t*)L_3);
		uint8_t L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(Angle_t0229F612898D65B3CC646C40A32D93D8A33C1DFC*)L_0 = ((*(Angle_t0229F612898D65B3CC646C40A32D93D8A33C1DFC*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		Angle_t0229F612898D65B3CC646C40A32D93D8A33C1DFC* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(Angle_t0229F612898D65B3CC646C40A32D93D8A33C1DFC));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		Angle_t0229F612898D65B3CC646C40A32D93D8A33C1DFC* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(Angle_t0229F612898D65B3CC646C40A32D93D8A33C1DFC));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisBackground_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8_m42F91ABC36A1F9694EAE71D11F91C9F26FE3A95D (uint8_t* ___0_source, Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		uint8_t* L_3 = ___0_source;
		uint8_t L_4 = (*(uint8_t*)L_3);
		uint8_t L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8*)L_0 = ((*(Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		Il2CppCodeGenWriteBarrier((void**)&(((Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8*)L_0)->___m_Texture), (void*)NULL);
		#if IL2CPP_ENABLE_STRICT_WRITE_BARRIERS
		Il2CppCodeGenWriteBarrier((void**)&(((Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8*)L_0)->___m_Sprite), (void*)NULL);
		#endif
		#if IL2CPP_ENABLE_STRICT_WRITE_BARRIERS
		Il2CppCodeGenWriteBarrier((void**)&(((Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8*)L_0)->___m_RenderTexture), (void*)NULL);
		#endif
		#if IL2CPP_ENABLE_STRICT_WRITE_BARRIERS
		Il2CppCodeGenWriteBarrier((void**)&(((Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8*)L_0)->___m_VectorImage), (void*)NULL);
		#endif
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(Background_t3C720DED4FAF016332D29FB86C9BE8D5D0D8F0C8));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisBackgroundPosition_tF0822B29FC27A67205A9893EBE03D03B799B8B56_mDA5E32F4E7E44CA373443CED922FCACFC5431A5D (uint8_t* ___0_source, BackgroundPosition_tF0822B29FC27A67205A9893EBE03D03B799B8B56* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		BackgroundPosition_tF0822B29FC27A67205A9893EBE03D03B799B8B56* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		uint8_t* L_3 = ___0_source;
		uint8_t L_4 = (*(uint8_t*)L_3);
		uint8_t L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(BackgroundPosition_tF0822B29FC27A67205A9893EBE03D03B799B8B56*)L_0 = ((*(BackgroundPosition_tF0822B29FC27A67205A9893EBE03D03B799B8B56*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		BackgroundPosition_tF0822B29FC27A67205A9893EBE03D03B799B8B56* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(BackgroundPosition_tF0822B29FC27A67205A9893EBE03D03B799B8B56));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		BackgroundPosition_tF0822B29FC27A67205A9893EBE03D03B799B8B56* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(BackgroundPosition_tF0822B29FC27A67205A9893EBE03D03B799B8B56));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisBackgroundRepeat_t446EC7315DED2C6822F1047B7587C3018BFB277F_m0CBD471F06E7A129FBB27057A32F1E804912AE0A (uint8_t* ___0_source, BackgroundRepeat_t446EC7315DED2C6822F1047B7587C3018BFB277F* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		BackgroundRepeat_t446EC7315DED2C6822F1047B7587C3018BFB277F* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		uint8_t* L_3 = ___0_source;
		uint8_t L_4 = (*(uint8_t*)L_3);
		uint8_t L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(BackgroundRepeat_t446EC7315DED2C6822F1047B7587C3018BFB277F*)L_0 = ((*(BackgroundRepeat_t446EC7315DED2C6822F1047B7587C3018BFB277F*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		BackgroundRepeat_t446EC7315DED2C6822F1047B7587C3018BFB277F* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(BackgroundRepeat_t446EC7315DED2C6822F1047B7587C3018BFB277F));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		BackgroundRepeat_t446EC7315DED2C6822F1047B7587C3018BFB277F* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(BackgroundRepeat_t446EC7315DED2C6822F1047B7587C3018BFB277F));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisBackgroundSize_t809883E2D7BB1D8D85B4C3E1DBE189F187DB25E7_mDB9D92A80308945E9F05C655C2B1414E771D8AFD (uint8_t* ___0_source, BackgroundSize_t809883E2D7BB1D8D85B4C3E1DBE189F187DB25E7* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		BackgroundSize_t809883E2D7BB1D8D85B4C3E1DBE189F187DB25E7* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		uint8_t* L_3 = ___0_source;
		uint8_t L_4 = (*(uint8_t*)L_3);
		uint8_t L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(BackgroundSize_t809883E2D7BB1D8D85B4C3E1DBE189F187DB25E7*)L_0 = ((*(BackgroundSize_t809883E2D7BB1D8D85B4C3E1DBE189F187DB25E7*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		BackgroundSize_t809883E2D7BB1D8D85B4C3E1DBE189F187DB25E7* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(BackgroundSize_t809883E2D7BB1D8D85B4C3E1DBE189F187DB25E7));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		BackgroundSize_t809883E2D7BB1D8D85B4C3E1DBE189F187DB25E7* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(BackgroundSize_t809883E2D7BB1D8D85B4C3E1DBE189F187DB25E7));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_mF7394892702C1F93C1768D0BDD10C5E0000E6725 (uint8_t* ___0_source, bool* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		bool* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		uint8_t* L_3 = ___0_source;
		uint8_t L_4 = (*(uint8_t*)L_3);
		uint8_t L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(bool*)L_0 = ((*(bool*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		bool* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(bool));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		bool* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(bool));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_m945EFDFB726DEB7229B283A96F2126B7D236CDA7 (uint8_t* ___0_source, uint8_t* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		uint8_t* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		uint8_t* L_3 = ___0_source;
		uint8_t L_4 = (*(uint8_t*)L_3);
		uint8_t L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(uint8_t*)L_0 = ((*(uint8_t*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		uint8_t* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(uint8_t));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		uint8_t* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(uint8_t));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisChar_t521A6F19B456D956AF452D926C32709DC03D6B17_m1AAE0A4991AB59550B63763D595F9FCE542188F4 (uint8_t* ___0_source, Il2CppChar* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		Il2CppChar* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		uint8_t* L_3 = ___0_source;
		uint8_t L_4 = (*(uint8_t*)L_3);
		uint8_t L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(Il2CppChar*)L_0 = ((*(Il2CppChar*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		Il2CppChar* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(Il2CppChar));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		Il2CppChar* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(Il2CppChar));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisColor_tD001788D726C3A7F1379BEED0260B9591F440C1F_m5BA67301352E941DFFDCE7A6B2171729F7BA203F (uint8_t* ___0_source, Color_tD001788D726C3A7F1379BEED0260B9591F440C1F* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		uint8_t* L_3 = ___0_source;
		uint8_t L_4 = (*(uint8_t*)L_3);
		uint8_t L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(Color_tD001788D726C3A7F1379BEED0260B9591F440C1F*)L_0 = ((*(Color_tD001788D726C3A7F1379BEED0260B9591F440C1F*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(Color_tD001788D726C3A7F1379BEED0260B9591F440C1F));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		Color_tD001788D726C3A7F1379BEED0260B9591F440C1F* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(Color_tD001788D726C3A7F1379BEED0260B9591F440C1F));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisCursor_t24C3B5095F65B86794C4F7EA168E324DFDA9EE82_mF6BA36758D03584BEC974C01B3E73FAF2ADDE327 (uint8_t* ___0_source, Cursor_t24C3B5095F65B86794C4F7EA168E324DFDA9EE82* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		Cursor_t24C3B5095F65B86794C4F7EA168E324DFDA9EE82* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		uint8_t* L_3 = ___0_source;
		uint8_t L_4 = (*(uint8_t*)L_3);
		uint8_t L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(Cursor_t24C3B5095F65B86794C4F7EA168E324DFDA9EE82*)L_0 = ((*(Cursor_t24C3B5095F65B86794C4F7EA168E324DFDA9EE82*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		Cursor_t24C3B5095F65B86794C4F7EA168E324DFDA9EE82* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(Cursor_t24C3B5095F65B86794C4F7EA168E324DFDA9EE82));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		Cursor_t24C3B5095F65B86794C4F7EA168E324DFDA9EE82* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(Cursor_t24C3B5095F65B86794C4F7EA168E324DFDA9EE82));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisDateTime_t66193957C73913903DDAD89FEDC46139BCA5802D_m59FDC9A55EB9BC746E1B3D83D8C44D5797356873 (uint8_t* ___0_source, DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		uint8_t* L_3 = ___0_source;
		uint8_t L_4 = (*(uint8_t*)L_3);
		uint8_t L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D*)L_0 = ((*(DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisDouble_tE150EF3D1D43DEE85D533810AB4C742307EEDE5F_m1F6FA901BC5287346F5A7ECBDEA0A3E49ADCDC6D (uint8_t* ___0_source, double* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		double* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		uint8_t* L_3 = ___0_source;
		uint8_t L_4 = (*(uint8_t*)L_3);
		uint8_t L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(double*)L_0 = ((*(double*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		double* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(double));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		double* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(double));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisEasingFunction_t5197D3B06056326A8B5C96032CDEBD5D3BDCA7A4_m61853FDA66714D30BDB53A5C6C788C4BC7917DD3 (uint8_t* ___0_source, EasingFunction_t5197D3B06056326A8B5C96032CDEBD5D3BDCA7A4* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		EasingFunction_t5197D3B06056326A8B5C96032CDEBD5D3BDCA7A4* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		uint8_t* L_3 = ___0_source;
		uint8_t L_4 = (*(uint8_t*)L_3);
		uint8_t L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(EasingFunction_t5197D3B06056326A8B5C96032CDEBD5D3BDCA7A4*)L_0 = ((*(EasingFunction_t5197D3B06056326A8B5C96032CDEBD5D3BDCA7A4*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		EasingFunction_t5197D3B06056326A8B5C96032CDEBD5D3BDCA7A4* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(EasingFunction_t5197D3B06056326A8B5C96032CDEBD5D3BDCA7A4));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		EasingFunction_t5197D3B06056326A8B5C96032CDEBD5D3BDCA7A4* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(EasingFunction_t5197D3B06056326A8B5C96032CDEBD5D3BDCA7A4));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisFilterFunction_t32E0707BD9D9F770A2A7578985A5C163FC1AAEFF_m753A594B3ABFCD67E72E3F0C99926A419A48BC07 (uint8_t* ___0_source, FilterFunction_t32E0707BD9D9F770A2A7578985A5C163FC1AAEFF* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		FilterFunction_t32E0707BD9D9F770A2A7578985A5C163FC1AAEFF* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		uint8_t* L_3 = ___0_source;
		uint8_t L_4 = (*(uint8_t*)L_3);
		uint8_t L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(FilterFunction_t32E0707BD9D9F770A2A7578985A5C163FC1AAEFF*)L_0 = ((*(FilterFunction_t32E0707BD9D9F770A2A7578985A5C163FC1AAEFF*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		Il2CppCodeGenWriteBarrier((void**)&(((FilterFunction_t32E0707BD9D9F770A2A7578985A5C163FC1AAEFF*)L_0)->___m_CustomDefinition), (void*)NULL);
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		FilterFunction_t32E0707BD9D9F770A2A7578985A5C163FC1AAEFF* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(FilterFunction_t32E0707BD9D9F770A2A7578985A5C163FC1AAEFF));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		FilterFunction_t32E0707BD9D9F770A2A7578985A5C163FC1AAEFF* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(FilterFunction_t32E0707BD9D9F770A2A7578985A5C163FC1AAEFF));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73546
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool TypeConversion_TryConvertEnum_TisByte_t94D9231AC217BE4D2E004C4CD32DF6D099EA41A3_TisFontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C_m878FC203CAA0F1C72768946CBC6C3877879582D2 (uint8_t* ___0_source, FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C* ___1_destination, const RuntimeMethod* method) 
{
	il2cpp_rgctx_method_init(method);
	CHECKED_LOCAL(Type_t_StaticInit);
	CHECKED_LOCAL(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit);
	//<source_info:<no-source>:1>
	bool V_0 = false;
	il2cpp::utils::ExceptionSupportStack<RuntimeObject*, 1> __active_exceptions;
	{
		goto IL_008a;
	}
	try
	{
		FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C* L_0 = ___1_destination;
		RuntimeTypeHandle_t332A452B8B6179E4469B69525D0FE82A88030F7B L_1 = { reinterpret_cast<intptr_t> (il2cpp_rgctx_type(method->rgctx_data, 0)) };
		CHECKED_LOCAL_INIT(Type_t_StaticInit,(Type_t_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		Type_t* L_2;
		L_2 = Type_GetTypeFromHandle_m6062B81682F79A4D6DF2640692EE6D9987858C57(L_1, NULL);
		uint8_t* L_3 = ___0_source;
		uint8_t L_4 = (*(uint8_t*)L_3);
		uint8_t L_5 = L_4;
		RuntimeObject* L_6 = Box(il2cpp_rgctx_data(method->rgctx_data, 3), &L_5);
		CHECKED_LOCAL_INIT(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_StaticInit,(Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_il2cpp_TypeInfo_var),il2cpp_codegen_runtime_class_init_inline);
		RuntimeObject* L_7;
		L_7 = Enum_Parse_m2846B01D5DEA00E4674AED09DE0B2E59ECEED61F(L_2, ((String_t*)CastclassSealed((RuntimeObject*)L_6, String_t_il2cpp_TypeInfo_var)), NULL);
		*(FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C*)L_0 = ((*(FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C*)UnBox(L_7, il2cpp_rgctx_data(method->rgctx_data, 1))));
		Il2CppCodeGenWriteBarrier((void**)&(((FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C*)L_0)->___m_Font), (void*)NULL);
		#if IL2CPP_ENABLE_STRICT_WRITE_BARRIERS
		Il2CppCodeGenWriteBarrier((void**)&(((FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C*)L_0)->___m_FontAsset), (void*)NULL);
		#endif
		goto IL_0064;
	}
	catch(Il2CppExceptionWrapper& e)
	{
		if(il2cpp_codegen_class_is_assignable_from (((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263_il2cpp_TypeInfo_var)), il2cpp_codegen_object_class(e.ex)))
		{
			IL2CPP_PUSH_ACTIVE_EXCEPTION(e.ex);
			goto CATCH_0058;
		}
		throw e;
	}

CATCH_0058:
	{
		ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263* L_8 = ((ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*)IL2CPP_GET_ACTIVE_EXCEPTION(ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263*));;
		FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C* L_9 = ___1_destination;
		il2cpp_codegen_initobj(L_9, sizeof(FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C));
		V_0 = (bool)0;
		IL2CPP_POP_ACTIVE_EXCEPTION(Exception_t*);
		goto IL_0093;
	}

IL_0064:
	{
		return (bool)1;
	}

IL_008a:
	{
		FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C* L_10 = ___1_destination;
		il2cpp_codegen_initobj(L_10, sizeof(FontDefinition_t65281B0E106365C28AD3F2525DE148719AEEA30C));
		return (bool)0;
	}

IL_0093:
	{
		bool L_11 = V_0;
		return L_11;
	}
}
// Method Definition Index: 73541
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471 TypeConverter_2_Invoke_mC00EB2E2FCBECD90D43B086E367A5588CFB7AF75_gshared_inline (TypeConverter_2_tF89582388D90E6733D9336D56E72113181F8C35B* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	typedef StyleMaterialDefinition_tD636761D4A563CA86667B8A4824D599FD008B471 (*FunctionPointerType) (RuntimeObject*, Il2CppSharedGenericObject**, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_value, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 73541
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF TypeConverter_2_Invoke_m9364011AA418E118526924552C4365CDBE204F0C_gshared_inline (TypeConverter_2_t6639570A10ABBF2F824E8BC88925BA36914DC1C7* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	typedef StylePropertyName_tCBE2B561C690538C8514BF56426AC486DC35B6FF (*FunctionPointerType) (RuntimeObject*, Il2CppSharedGenericObject**, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_value, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 73541
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906 TypeConverter_2_Invoke_m8BAF3CB8DC77C7156495925FCEB4DD4EBD2A166D_gshared_inline (TypeConverter_2_t14B52AF1258A5A9C9C7C40B585BCC796EB89546E* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	typedef StyleRatio_t7F5BA86302D3F11C5E1A8CB91AB7BFA3B5B75906 (*FunctionPointerType) (RuntimeObject*, Il2CppSharedGenericObject**, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_value, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 73541
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B TypeConverter_2_Invoke_m2E33325E79FFF74B5F0696488BE57DC3D7DCB412_gshared_inline (TypeConverter_2_t0D424B5552ED05121DAA8FBC96BFA5B5D7C25841* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	typedef StyleRotate_t59305F0FBB44EA70AE332ECF9279C270B3F2283B (*FunctionPointerType) (RuntimeObject*, Il2CppSharedGenericObject**, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_value, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 73541
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC TypeConverter_2_Invoke_m301828B6620219C395E629511178814425BBA544_gshared_inline (TypeConverter_2_t325870E3CF7DE93A02F5E359A73B09EE687F7764* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	typedef StyleScale_t45D687B313B39CD6FB3686ED44DECDDA402923BC (*FunctionPointerType) (RuntimeObject*, Il2CppSharedGenericObject**, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_value, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 73541
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A TypeConverter_2_Invoke_mDE9C8CB32A3B1147B5AFF244AB7647F2EE4C310E_gshared_inline (TypeConverter_2_t77EBC7DE8779DBFC8C888CCCBA1C57A1900F8D0E* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	typedef StyleTextAutoSize_t1F33415D18D97D0242C4C2C450BEF0B475253F4A (*FunctionPointerType) (RuntimeObject*, Il2CppSharedGenericObject**, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_value, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 73541
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252 TypeConverter_2_Invoke_mBE4E53C83E451210FA4A9D332098E0DBD397DDFA_gshared_inline (TypeConverter_2_t2590D829276A4C224936EDAFCF1D1137DC63F062* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	typedef StyleTextShadow_tCDDF1FE733ADBAA5ACA3B74620D4728E83F54252 (*FunctionPointerType) (RuntimeObject*, Il2CppSharedGenericObject**, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_value, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 73541
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6 TypeConverter_2_Invoke_mB032B3ECE8561B150D6ACFC6C00837DB7C97AD25_gshared_inline (TypeConverter_2_t3B4B4ED61AFE2B4C7E58725FA7AE976658EDFC5F* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	typedef StyleTransformOrigin_t708B2E73541ECAE23D286FE68D6BC2CCFAAB84A6 (*FunctionPointerType) (RuntimeObject*, Il2CppSharedGenericObject**, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_value, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 73541
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089 TypeConverter_2_Invoke_m3927B7CA3A864D22F9C90042FACFAD85E8470864_gshared_inline (TypeConverter_2_tE6C2466AFC58085EAE6299B76802C78CC1C80F0D* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	typedef StyleTranslate_tF9528CA4B45EE4EB2C4D294336A83D88DB6AF089 (*FunctionPointerType) (RuntimeObject*, Il2CppSharedGenericObject**, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_value, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 73541
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5 TypeConverter_2_Invoke_m66AB21C3C933003F4B10DB738B579AFF92767A3D_gshared_inline (TypeConverter_2_tE2027A3B32E1BB438286300A403B88A772D4E99F* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	typedef StyleUIAnimationClip_t086DB226C1ACBC1C18CBA748C1BEA3A07E820DE5 (*FunctionPointerType) (RuntimeObject*, Il2CppSharedGenericObject**, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_value, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 73541
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A TypeConverter_2_Invoke_mE56444FC16A71452E074A8C12A28AEE28120D830_gshared_inline (TypeConverter_2_t73501A4CF3B35838D78DF2D56FF13675BEADC04B* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	typedef TextAutoSize_t8B7DB1DB1B1C9EF3DE876BB4D487CB00DBE3207A (*FunctionPointerType) (RuntimeObject*, Il2CppSharedGenericObject**, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_value, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 73541
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05 TypeConverter_2_Invoke_m5EFB8A4B526E5038BBEB12C50358AA67406DC302_gshared_inline (TypeConverter_2_tC0A832D8646E8260644D66DD7FA213AC57484831* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	typedef TextShadow_t6BADF37AB90ABCB63859A225B58AC5A580950A05 (*FunctionPointerType) (RuntimeObject*, Il2CppSharedGenericObject**, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_value, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 73541
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A TypeConverter_2_Invoke_m8A30F6853F5EE6FCFDE935B43D200CCAA09136B4_gshared_inline (TypeConverter_2_t0A5CBF00DFB82526AEB7B2DFEF71CA4F4807581E* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	typedef TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A (*FunctionPointerType) (RuntimeObject*, Il2CppSharedGenericObject**, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_value, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 73541
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E TypeConverter_2_Invoke_mDFB5642B7FB6B4442DBC14B2F31EF44601F04D38_gshared_inline (TypeConverter_2_tBA10E08FB2B7207E85EAB1039CE76A8D80224B20* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	typedef TimeValue_t45AE43B219493F9459363F32C79E8986B5F82E0E (*FunctionPointerType) (RuntimeObject*, Il2CppSharedGenericObject**, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_value, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 73541
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502 TypeConverter_2_Invoke_mCE58430324F9B994275CA0432152E6690C870493_gshared_inline (TypeConverter_2_t26D60543337DCCA819FD538D85F40D86762DB0F2* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	typedef TransformOrigin_tD11A368A96C0771398EBB4E6D435318AC0EF8502 (*FunctionPointerType) (RuntimeObject*, Il2CppSharedGenericObject**, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_value, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 73541
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E TypeConverter_2_Invoke_mD793CD9960E098A5D8B04701404212678B3C4087_gshared_inline (TypeConverter_2_tC8DC9C48FBE571CF2E75D0324F34468EACBEB008* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	typedef Translate_t494F6E802F8A640D67819C9D26BE62DED1218A8E (*FunctionPointerType) (RuntimeObject*, Il2CppSharedGenericObject**, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_value, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 73541
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint16_t TypeConverter_2_Invoke_m66222088B81B0479C4FAED81A6E115C2078D89A2_gshared_inline (TypeConverter_2_t7104BAD86AB01041A6B4CFA05DD8A0CF7B316EAE* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	typedef uint16_t (*FunctionPointerType) (RuntimeObject*, Il2CppSharedGenericObject**, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_value, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 73541
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint32_t TypeConverter_2_Invoke_mCBE8A03AC2A93E11AC276C8AB69B069E2DC24E9F_gshared_inline (TypeConverter_2_t987BA7DD2FE661C6A4CD1CE7F398720A1A912CDB* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	typedef uint32_t (*FunctionPointerType) (RuntimeObject*, Il2CppSharedGenericObject**, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_value, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 73541
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR uint64_t TypeConverter_2_Invoke_mEA8D3ECFB70460557F24848D00C2A296D047A36F_gshared_inline (TypeConverter_2_tFE7942B61544B13EC61F654A379BB8C5C19E478F* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	typedef uint64_t (*FunctionPointerType) (RuntimeObject*, Il2CppSharedGenericObject**, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_value, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 73541
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 TypeConverter_2_Invoke_m49AE9030B92C77BF35406171E80F83866E190EEB_gshared_inline (TypeConverter_2_t4C7D6F1114B9EFC390F0FE6F2860EDC1E7DF3049* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	typedef Vector2_t1FD6F485C871E832B347AB2DC8CBA08B739D8DF7 (*FunctionPointerType) (RuntimeObject*, Il2CppSharedGenericObject**, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_value, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 73541
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 TypeConverter_2_Invoke_m9A7F8EB799C5DB7CC4A9461CF3A66B1A424F189D_gshared_inline (TypeConverter_2_tA9C93925BAFC7D4786356A2B45762EB2575F3986* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	typedef Vector3_t24C512C7B96BBABAD472002D0BA2BDA40A5A80B2 (*FunctionPointerType) (RuntimeObject*, Il2CppSharedGenericObject**, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_value, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 73541
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 TypeConverter_2_Invoke_m88BD1040FEFBC4E99093EA05FF231808CAFDB905_gshared_inline (TypeConverter_2_t2257368AB189DB95AF22DD35774E8FEB55C630BB* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	typedef Vector3Int_t65CB06F557251D18A37BD71F3655BA836A357376 (*FunctionPointerType) (RuntimeObject*, Il2CppSharedGenericObject**, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_value, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 73541
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Il2CppSharedGenericObject* TypeConverter_2_Invoke_mF0FFFFF940DA8BB84CBB0B4BD67E875750ADA97C_gshared_inline (TypeConverter_2_t0525BA89BAB435F8C9F2EEF9023F9BCB7ABE80A1* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	typedef Il2CppSharedGenericObject* (*FunctionPointerType) (RuntimeObject*, Il2CppSharedGenericObject**, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_value, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 32564
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Il2CppSharedGenericObject** UnsafeUtility_As_TisIl2CppSharedGenericObject_TisIl2CppSharedGenericObject_m7E01BE5B3130A632C43D1F86A8781C30A93D3DCF_gshared_inline (Il2CppSharedGenericObject** ___0_from, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		Il2CppSharedGenericObject** L_0 = ___0_from;
		Il2CppSharedGenericObject** L_1;
		L_1 = UnsafeUtilityInternal_As_TisIl2CppSharedGenericObject_TisIl2CppSharedGenericObject_m1C63CD01558497B8FF90637D897964E5BF4FAC2A_inline(L_0, NULL);
		return L_1;
	}
}
// Method Definition Index: 73541
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t TypeConverter_2_Invoke_m7765922B627FE0A4912228208A85C752498BDC44_gshared_inline (TypeConverter_2_t81D4A80534427AD7BC452191F15131144F2FF763* __this, Il2CppSharedGenericObject** ___0_value, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	typedef int32_t (*FunctionPointerType) (RuntimeObject*, Il2CppSharedGenericObject**, const RuntimeMethod*);
	return ((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_value, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
// Method Definition Index: 32564
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t* UnsafeUtility_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_m9AEA7CA3ED58CAAF5CC970EF8B1182B9DC69D464_gshared_inline (bool* ___0_from, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		bool* L_0 = ___0_from;
		int32_t* L_1;
		L_1 = UnsafeUtilityInternal_As_TisBoolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_Tis__Il2CppInt32Enum_tE5E90BB5D60D5281C33DB29D9DCBD70D5E2E1F7B_mD2CFD786E18565D81928F220F62310DF589EEF5C_inline(L_0, NULL);
		return L_1;
	}
}
// Method Definition Index: 78310
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Il2CppFullySharedGenericAny* UnsafeUtilityInternal_As_TisIl2CppFullySharedGenericAny_TisIl2CppFullySharedGenericAny_mE1CA751887466B801BE69083C2B0EA3EDE41FF9B_fshared_inline (Il2CppFullySharedGenericAny* ___0_from, const RuntimeMethod* method) 
{
	//<source_info:<no-source>:1>
	{
		Il2CppFullySharedGenericAny* L_0 = ___0_from;
		return (Il2CppFullySharedGenericAny*)(L_0);
	}
}
