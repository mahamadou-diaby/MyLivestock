using System;

namespace MyliveStock.core
{
    public class ServiceLocator
    {
        private static volatile ServiceLocator instance;
        private static object syncRoot = new object();

        public Autofac.IContainer Contenair { get; set; }

        public ServiceLocator()
        { }

        public static ServiceLocator Curent
        {
            get
            {
                if(instance == null)
                {
                    lock(syncRoot)
                    {
                        if(instance == null)
                        {
                            instance = new ServiceLocator();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
