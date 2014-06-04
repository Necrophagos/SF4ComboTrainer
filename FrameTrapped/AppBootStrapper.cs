namespace FrameTrapped
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    using Caliburn.Micro;
    using FrameTrapped.Common.Utilities;
    using FrameTrapped.ViewModels;

    public class AppBootStrapper : Bootstrapper<MainViewModel>
    {
        /// <summary>
        /// The composition container.
        /// </summary>
        private SimpleContainer  _container;

        /// <summary>
        /// Configure the bootstrapper. Setup the CompositionContainer.
        /// </summary>
        protected override void Configure()
        {
            _container = new SimpleContainer ();
             

            _container.Instance<IWindowManager>(new  WindowManager());
            _container.Singleton<IEventAggregator,EventAggregator>(); 
              
            _container.PerRequest<MainViewModel>();
        }

        /// <summary>
        /// Select the assemblies that contain model views.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            List<Assembly> assemblies = new List<Assembly>();
            assemblies.Add(Assembly.GetExecutingAssembly());
            assemblies.Add(Assembly.Load("FrameTrapped.Home"));
            assemblies.Add(Assembly.Load("FrameTrapped.Input"));
            assemblies.Add(Assembly.Load("FrameTrapped.StreetFighterLibrary"));
            assemblies.Add(Assembly.Load("FrameTrapped.ComboTrainer"));

            return assemblies;
        }

        protected override void OnExit(object sender, System.EventArgs e)
        {
            Roadie.Instance.Dispose();
            base.OnExit(sender, e);
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>( );
        }
 
    }
}
