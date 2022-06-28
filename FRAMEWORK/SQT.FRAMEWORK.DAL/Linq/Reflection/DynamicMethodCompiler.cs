using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;
using SQT.FRAMEWORK.DAL.Linq.Exceptions;

public delegate Object GetPropertyHandler(object source);
public delegate void SetPropertyHandler(object sourceClass, object value);
public delegate Object InstanceCreateHandler();

namespace SQT.FRAMEWORK.DAL.Linq.Reflection
{

    public static class DynamicMethodCompiler
    {
        public static InstanceCreateHandler CreateInstance<T>()
        {
            Type t = typeof(T);
            ConstructorInfo constructor = t.GetConstructor(BindingFlags.Public |
                                                           BindingFlags.NonPublic |
                                                           BindingFlags.Instance
                                                           , null, new Type[0], null);

            if (constructor == null)
            {
                throw new LinqSqlException(
                    string.Format("The type {0} must declare an empty public constructor.", t));
            }

            DynamicMethod dynamicMethod = new DynamicMethod("ObjectInstance",
                                                            MethodAttributes.Static |
                                                            MethodAttributes.Public,
                                                            CallingConventions.Standard,
                                                            typeof(object), null, t, true);

            ILGenerator generator = dynamicMethod.GetILGenerator();
            generator.Emit(OpCodes.Newobj, constructor);
            generator.Emit(OpCodes.Ret);
            return (InstanceCreateHandler)dynamicMethod.CreateDelegate(typeof(InstanceCreateHandler));
        }

        public static InstanceCreateHandler CreateInstance<T>(ConstructorInfo constructor)
        {
            Type t = typeof(T);
            if (constructor == null)
            {
                throw new LinqSqlException(
                    string.Format("The type {0} must declare an empty public constructor.", t));
            }

            DynamicMethod dynamicMethod = new DynamicMethod("ObjectInstance",
                                                            MethodAttributes.Static |
                                                            MethodAttributes.Public,
                                                            CallingConventions.Standard,
                                                            typeof(object), null, t, true);

            ILGenerator generator = dynamicMethod.GetILGenerator();
            generator.Emit(OpCodes.Newobj, constructor);
            generator.Emit(OpCodes.Ret);
            return (InstanceCreateHandler)dynamicMethod.CreateDelegate(typeof(InstanceCreateHandler));
        }

        public static InstanceCreateHandler CreateStructInstance<T>()
        {
            Type t = typeof(T);
            DynamicMethod dynamicMethod = new DynamicMethod("InstantiateStruct"
                                                            , MethodAttributes.Static |
                                                            MethodAttributes.Public
                                                            , CallingConventions.Standard
                                                            , typeof(object), null, t, true);
            dynamicMethod.InitLocals = true;
            ILGenerator generator = dynamicMethod.GetILGenerator();
            LocalBuilder local = generator.DeclareLocal(t);
            generator.Emit(OpCodes.Ldloc_0);
            generator.Emit(OpCodes.Box, t);
            generator.Emit(OpCodes.Ret);
            return (InstanceCreateHandler)dynamicMethod.CreateDelegate(typeof(InstanceCreateHandler));
        }

        public static GetPropertyHandler CreatePropertyGetHandler<T>(PropertyInfo propertyInfo)
        {
            MethodInfo getMethodInfo = propertyInfo.GetGetMethod();
            if (null == getMethodInfo) { return null; } //Guard clause if there's no getter
            DynamicMethod dynamicGet = CreateGetDynamicMethod<T>(propertyInfo);


            ILGenerator getGenerator = dynamicGet.GetILGenerator();
            getGenerator.Emit(OpCodes.Ldarg_0);
            getGenerator.Emit(OpCodes.Call, getMethodInfo);
            BoxIfNeeded(getMethodInfo.ReturnType, getGenerator);
            getGenerator.Emit(OpCodes.Ret);

            return (GetPropertyHandler)dynamicGet.CreateDelegate(typeof(GetPropertyHandler));
        }

        public static SetPropertyHandler CreateSetPropertyHandler<T>(PropertyInfo propertyInfo)
        {
            MethodInfo setMethodInfo = propertyInfo.GetSetMethod(true);
            DynamicMethod dynamicSet = CreateSetDynamicMethod<T>(propertyInfo.Name);
            ILGenerator setGenerator = dynamicSet.GetILGenerator();

            setGenerator.Emit(OpCodes.Ldarg_0);
            setGenerator.Emit(OpCodes.Ldarg_1);
            UnboxIfNeeded(setMethodInfo.GetParameters()[0].ParameterType, setGenerator);
            setGenerator.Emit(OpCodes.Call, setMethodInfo);
            setGenerator.Emit(OpCodes.Ret);

            return (SetPropertyHandler)dynamicSet.CreateDelegate(typeof(SetPropertyHandler));
        }


        private static DynamicMethod CreateGetDynamicMethod<T>(PropertyInfo property)
        {
            return new DynamicMethod(String.Concat("_Get", property.Name, "_")
                                    , typeof(object) //The return type
                                    , new Type[] { typeof(object) } //type sent into the method
                                    , typeof(T), true); //class this type is associated to       
        }

        private static DynamicMethod CreateSetDynamicMethod<T>(string propertyName)
        {
            return new DynamicMethod(String.Concat("_Set", propertyName, "_")
                                    , typeof(void)
                                    , new Type[] { typeof(object), typeof(object) }
                                    , typeof(T), true);
        }

        private static void BoxIfNeeded(Type type, ILGenerator generator)
        {
            if (type.IsValueType)
            {
                generator.Emit(OpCodes.Box, type);
            }
        }

        private static void UnboxIfNeeded(Type type, ILGenerator generator)
        {
            if (type.IsValueType)
            {
                generator.Emit(OpCodes.Unbox_Any, type);
            }
        }
    }

}