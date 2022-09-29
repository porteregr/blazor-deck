using System;
using System.Reflection;

namespace BlazorDeck.Shared.BaseClasses
{
    public class TypeSelection : Named
    {
        public TypeInfo TypeInfo { get; }
        public Type BuilderFor { get; }
        public TypeSelection(TypeInfo typeInfo, Type builderFor) : base(typeInfo.Name)
        {
            TypeInfo = typeInfo;
            BuilderFor = builderFor;
        }
    }
}
