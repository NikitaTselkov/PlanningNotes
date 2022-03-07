using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ViewModels.WindowAndPageService
{
    public static class DisplayRootRegistry
    {
        private static Dictionary<Type, Type> _vmToWindowMapping = new Dictionary<Type, Type>();
        private static Dictionary<Type, Type> _vmToPageMapping = new Dictionary<Type, Type>();

        /// <summary>
        /// Регистрирует окно.
        /// </summary>
        /// <typeparam name="VM"> ViewModel. </typeparam>
        /// <typeparam name="Win"> Окно. </typeparam>
        public static void RegisterWindowType<VM, Win>() where Win : Window, new() where VM : class
        {
            var vmType = typeof(VM);
            if (vmType.IsInterface)
                throw new ArgumentException("Cannot register interfaces");
            if (_vmToWindowMapping.ContainsKey(vmType))
                throw new InvalidOperationException(
                    $"Type {vmType.FullName} is already registered");
            _vmToWindowMapping[vmType] = typeof(Win);
        }

        /// <summary>
        /// Регистрирует страницу.
        /// </summary>
        /// <typeparam name="VM"> ViewModel. </typeparam>
        /// <typeparam name="Page"> Страница. </typeparam>
        public static void RegisterPageType<VM, Page>() where Page : System.Windows.Controls.Page, new() where VM : class
        {
            var vmType = typeof(VM);
            if (vmType.IsInterface)
                throw new ArgumentException("Cannot register interfaces");
            if (_vmToPageMapping.ContainsKey(vmType))
                throw new InvalidOperationException(
                    $"Type {vmType.FullName} is already registered");
            _vmToPageMapping[vmType] = typeof(Page);
        }

        /// <summary>
        /// Удаляет регистрацию окна.
        /// </summary>
        /// <typeparam name="VM"> ViewModel. </typeparam>
        public static void UnregisterWindowType<VM>()
        {
            var vmType = typeof(VM);
            if (vmType.IsInterface)
                throw new ArgumentException("Cannot register interfaces");
            if (!_vmToWindowMapping.ContainsKey(vmType))
                throw new InvalidOperationException(
                    $"Type {vmType.FullName} is not registered");
            _vmToWindowMapping.Remove(vmType);
        }

        /// <summary>
        /// Удаляет регистрацию страницы.
        /// </summary>
        /// <typeparam name="VM"> ViewModel. </typeparam>
        public static void UnregisterPageType<VM>()
        {
            var vmType = typeof(VM);
            if (vmType.IsInterface)
                throw new ArgumentException("Cannot register interfaces");
            if (!_vmToPageMapping.ContainsKey(vmType))
                throw new InvalidOperationException(
                    $"Type {vmType.FullName} is not registered");
            _vmToPageMapping.Remove(vmType);
        }

        /// <summary>
        /// Создает экземпляр окна с помощью ViewModel.
        /// </summary>
        /// <param name="vm"> ViewModel. </param>
        /// <returns> Окно. </returns>
        public static Window CreateWindowInstanceWithVM(object vm)
        {
            if (vm == null)
                throw new ArgumentNullException("vm");
            Type windowType = null;

            var vmType = vm.GetType();
            while (vmType != null && !_vmToWindowMapping.TryGetValue(vmType, out windowType))
                vmType = vmType.BaseType;

            if (windowType == null)
                throw new ArgumentException(
                    $"No registered window type for argument type {vm.GetType().FullName}");

            var window = (Window)Activator.CreateInstance(windowType);
            window.DataContext = vm;
            return window;
        }

        /// <summary>
        /// Создает экземпляр страницы с помощью ViewModel.
        /// </summary>
        /// <param name="vm"> ViewModel. </param>
        /// <returns> Страницу. </returns>
        public static Page CreatePageInstanceWithVM(object vm)
        {
            if (vm == null)
                throw new ArgumentNullException("vm");
            Type pageType = null;

            var vmType = vm.GetType();
            while (vmType != null && !_vmToPageMapping.TryGetValue(vmType, out pageType))
                vmType = vmType.BaseType;

            if (pageType == null)
                throw new ArgumentException(
                    $"No registered page type for argument type {vm.GetType().FullName}");

            var page = (Page)Activator.CreateInstance(pageType);
            page.DataContext = vm;
            return page;
        }

        static Dictionary<object, Window> openWindows = new Dictionary<object, Window>();

        /// <summary>
        /// Создает окно.
        /// </summary>
        /// <param name="vm"> ViewModel. </param>
        public static void ShowPresentation(object vm)
        {
            if (vm == null)
                throw new ArgumentNullException("vm");
            if (openWindows.ContainsKey(vm))
                throw new InvalidOperationException("UI for this VM is already displayed");
            var window = CreateWindowInstanceWithVM(vm);
            window.Show();
            openWindows[vm] = window;
        }

        /// <summary>
        /// Закрывает окно.
        /// </summary>
        /// <param name="vm"> ViewModel. </param>
        public static void ClosePresentation(object vm)
        {
            Window window;
            if (!openWindows.TryGetValue(vm, out window))
                throw new InvalidOperationException("UI for this VM is not displayed");
            window.Close();
            openWindows.Remove(vm);
        }

        /// <summary>
        /// Создает диалоговое окно.
        /// </summary>
        /// <param name="vm"> ViewModel. </param>
        public static void ShowModalPresentation(object vm)
        {
            var window = CreateWindowInstanceWithVM(vm);
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            openWindows[vm] = window;
            window.ShowDialog();
        }
    }
}
