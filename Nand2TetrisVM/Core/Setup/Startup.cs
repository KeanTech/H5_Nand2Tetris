using Microsoft.Extensions.DependencyInjection;
using Nand2TetrisVM.Core.Factories;
using Nand2TetrisVM.Core.FileHandlers;
using Nand2TetrisVM.Core.LogicConvertion;
using Nand2TetrisVM.Core.Managers;
using Nand2TetrisVM.Interfaces;
using Nand2TetrisVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nand2TetrisVM.Core.Setup
{
    public class Startup
    {
        public static IServiceProvider Initialize() 
        {
            IServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<FileHandler>()
                .AddSingleton<ICommandParser, Parser<VmLine>>()
                .AddSingleton<IFactory, CommandFactory>()
                .AddSingleton<ITranslatorManager, TranslatorManager>()
                .AddSingleton<AsmBuilder>()
                .BuildServiceProvider();

            return serviceProvider;
        }

    }
}
