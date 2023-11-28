﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transversal.Common
{
    public interface IAppLogger<T>
    {
        public void LogError(string message, params object[] args);
        public void LogInformation(string message, params object[] args);
        public void LogWarning(string message, params object[] args);

    }
}
