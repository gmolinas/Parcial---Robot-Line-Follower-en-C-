using System;

namespace Infrastructure.Tools
{
    public static class TypeLoader
    {
        public static T LoadInstance<T>(string typeName)
        {
            Type type = Type.GetType(typeName);
            if (type == null)
                throw new ArgumentException($"Tipo no encontrado: {typeName}");

            return (T)Activator.CreateInstance(type);
        }
    }
}
