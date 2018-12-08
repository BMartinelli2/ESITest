using SimpleInjector;

namespace EsiTest.StringReverser
{
    public class ModuleBindings
    {
        public Container DependencyContainer { get; private set; } = new Container();

        /// <summary>
        /// Register modules with the IOC container.
        /// </summary>
        public void RegisterModules()
        {
            DependencyContainer.Register<IStringReverser, SlowStringReverser>();
            DependencyContainer.Register<IConsoleReader, ConsoleReader>();
            DependencyContainer.Register<IInputHandler, InputHandler>();
        }
        
    }
}