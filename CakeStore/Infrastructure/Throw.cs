using System;

namespace CakeStore.Infrastructure
{
    public static class Throw
    {
        public static void IfArgumentNull(object parameter, string name)
        {
            if (parameter == null)
                throw new ArgumentNullException(name);
        }
    }
}