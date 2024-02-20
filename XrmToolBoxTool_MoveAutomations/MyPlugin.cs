using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace XrmToolBoxTool_MoveAutomations
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    //icon by <a href="https://www.freepik.com/icon/jackalope_3609684">Icon by Freepik</a>
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Transfer Automations"),
        ExportMetadata("Description", "Transfer Automations from a solution in one environment to a solution in another evnironment."),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAAA7AAAAOwBeShxvQAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAd3SURBVFiFrZVrcJTlFcd / 73133 / fdzSbZTQghgSgJCQQIxHDVSqEdLhZv2LEgqNOW4nQs2lGR0ZmOta0znVJrVaa20wofiK1Op7WtMnTUWqUjchUQMXFDIJQl9 + w9e3 / 6IaWiZTcZh / PxvOf5//7PmfOeBwqEZek/9Fj6Y5elKrweR7tl6u0Fz5j6S16Pox3wX8qZpr7dculPFDpTMBy6+gNJkvK6rqwH/JZL6y9xO7Kaptxd6IymKfd4bCNrubQ+wKcoyvoxDfXxYiy5QL5R15VMVYUVNwyl+8FvLkhXV7jDQFURreopVe7Q1nvbUoahdFdVWHFdUzJAQyG2bOr6sFPX0qW2OeT3uvcCtwAu4LTp0n+/eF61vPPJ1bUPbV6kTaqwckBdEQPTJvlt8ciWxfrOJ1fXLmyplkxTawc6ABO41e917y13WyGXrmVtQw9T4bGfMjVd+ExTuF0OMaeuOmc7jaTXcj0HTPF6HHuXL5kWjZzaJnbtuDnnto3TQO0V4LVu2zi9e8fafOTUNrF8ybSo1+14HZjitaydttORmj21Km87DVHudAqXqopqr+enAHJ1iSewec58sXX+AuGzTLF51RKxbmmLsBxGynLoj1mm8cz02tLYxUMPihd/tjbrtvRBoPEyeJPb0od27bg5Gzz4oKir8cYs03jG5dAfNx1G+pZFzWLDjfOEz3SJ7zXMFPdeUy+mlZecAZRLAp5Kt93/3ZY2se/2u0STzy++dt0s8ex9d4gFM6bmvLYrYJra0y2N/tFk53bx+q5v5D2W8W/AAiy3ZVzYu3t9Ptm5Xcxu8I2aTu3nXtvV1VZfm//xxlViRfN00eT1itdu+Kq495p6Mclt9QI2lzlIxVLpF4LJ2LpAaLjsl19axT8CXewPdPP925ZLlsMoPdl9cXbvYCzh1nLOTavrpHMXwvZHZ0fShqYu3XjT9DVb72yUfvGb98Qr+z4JK7K6eN2Suf6V8xqk3X8/iHdU8ELLYn7SeYKj8XBnz0i4CYhfbgAgFU2mdiZEzv9y56l5989pk+LJNPs+6uDOZa00T52sHero0Y91DIi+/rj88r6zEnn5ekWSbwj0ROWBoTi//fPHOZFTHA/fvty4dlIpL+59n9mqxXem1ZMrc2Vf7e155GSwfyOQvgSVCkzzwkq3/Xqrf5I3GIvSPKuGNW2zGIrEefYvb4vZ0yZLX57bQInpBCAUH+WtDzo40X1B3LfmekmX4Y1jHXR1BKlyujgcGY71RmIVQOLzoEIGADS/bf8olkw+LEB6ess6Sm1XkfKxiMTjDISiPLFnH4ok4XE5dgTD0e1A5kr1hZYQQKY/Gt2WyGRaNUXJ/utk17jwbDZLNpvlcEcPhqrk45nM/GA4+lAh+HgGLsXRSDK5+kBHd3a8wnR2jHOsOyjCydRK4Oh4ZyZiAOCtZDZb8BaXIpvNAXBhOAywfyLCEzWQ2/Gt27rHK8qLPACGpgrAeTUNfOWNDzoKPSifhhib6elV5TKw8qoZ8JfYz/s8pjJenSyPyS1tqmNyeclTV8uAGkkk65pqJ40vJo91YEa1j+FovHoi+hMxoAkhJE1R+Ph8Hzv++GbBwuf/tp/AxUEkSUId64Z6NQyMOnQ13jsS4dd793PrkjkADEZiJNMZkukMg5EYADctmEn720cZjibQVSXFZSu3UIzrEEDk2POr197dYmgqdZXlALx28BRHPukBoLW+hk3LF1DjK0FVZPb88yg5wZ6JaE/EwMycyN8TT6aJJVNkc3lURebuFQtQlbEGblh2Hbl8ntFkmuhoClmSyWSydwFPAx8VEy/2FgCoDl3rumNxa025ZfLmydMISbCiZQbJTIZX3jmGJMG6pXPJ5/O882EXuqKxbGYD5weH2Xf8dH8smZwMFNyiRX8tWZa/fW2l/+Zlsxt1h65RW17GYDjGqweOYzsdbFrRxuKmOg51nOOv739IfWUly2bNwDKdmLpOMBR2RuKjfXkhDn8hA05d233LwnnVbpcTSZIwdI0yy6Sztw+v5UKWJEaiCfpCMRKpDCtbZuGxTRRZJpPLYTsM6ezA0MxkJvtMwUsW4Zfk8vnaqjLvZ5KW6eTri1rRUDgeCHI8EESXVO5YNB/b/HT7aqpKhcdNOpebDHgKQYoNYW2ZbWU+PySqouDzemhWVc72DQAwtcJHqdtEumykFFlGkiS8LheJVHoKEL4SpFgHPA5du+KHQ4FzvLT/EJrlRrXctO8/yOHAuc/USP/dig5dk4DSQpBiHbgQio9KAEcCZ5lbV4Miy3QG++gaGObkH35HeclYZwdGQty4+QE8Lif1VRXk8nmOBM5RX+kjPDqaB84XghTrwLloYtQQwJneAd491QnAe51n2PnoA/+DA/i8JTz/6AMc6DwDwLunOjnT1w9ANJGUgZ4vYiCrqkrfUCRGyzU1BEdCY7cNRWht/P+XuW1mIwPhKAAXhkM0T5nMcCyOoWtDQK4QpPgmzIs/dV3sM2v9ZQOhaGKthNhju5z3d/f0nPj8cArAdjqaJcRzI7HEhlLbdb4vFC2T4EgxxH8Aki3FFEj33LIAAAAASUVORK5CYII="),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class MyPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MyPluginControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public MyPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}