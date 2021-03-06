//-------------------------------------------------------------------------------
// <copyright file="ServiceHostCreator.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2011 Ninject Project Contributors
//   Author: Ian Davis (ian@innovatian.com)
//
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
//   you may not use this file except in compliance with one of the Licenses.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//   or
//       http://www.microsoft.com/opensource/licenses.mspx
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace Ninject.Extensions.Wcf
{
    using System;
    using System.ServiceModel;

    /// <summary>
    /// Creates ServiceLocatorServiceHost upon request.
    /// </summary>
    public class ServiceHostCreator : IServiceHostCreator
    {
        /// <summary>
        /// Creator function that users can override to change the default functionality and 
        /// provide alternate <c>ServiceHost</c> implementations.
        /// </summary>
        private static readonly Func<Type, Uri[], ServiceHost> creator = 
            (serviceType, baseAddresses) => new ServiceLocatorServiceHost(serviceType, baseAddresses);

        /// <summary>
        /// Creates a <c>ServiceHost</c> with the specified configuration.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="baseAddresses">The base addresses.</param>
        /// <returns>A new or existing service host reference for the specified type of service.</returns>
        public ServiceHost Create(Type serviceType, Uri[] baseAddresses)
        {
            return creator(serviceType, baseAddresses);
        }
    }
}