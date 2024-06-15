﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Modules.Core.Application.Interfaces.APIs.Services
{
    /// <summary>
    /// Contract for an example 
    /// Application
    /// Service
    /// </summary>
    public interface IExampleService
    {
        /// <summary>
        /// Example method
        /// </summary>
        /// <returns></returns>
        bool Do();

        /// <summary>
        /// Example method
        /// </summary>
        /// <returns></returns>
        string Hello();

    }
}
