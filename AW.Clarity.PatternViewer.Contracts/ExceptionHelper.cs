using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AWSOA.Core.Contracts.Exceptions;
using AW.Clarity.PatternViewer.Contracts.Interfaces;

namespace AW.Clarity.PatternViewer.Contracts
{
    public static class ExceptionHelper
    {
        /// <summary>
        /// unwrapping the service exception and rethrows specific service exception
        /// </summary>
        /// <param name="ex">The wrapped ice exception</param>
        public static void ReThrowCoreException(CommunicationException ex)
        {
            System.Exception newExeption = ex;
            try
            {
                // try to throw the specific exception
                string fullName = (string.IsNullOrEmpty(ex.InnerTypeNameSpace)) ? "" : ex.InnerTypeNameSpace + ".";
                fullName += (string.IsNullOrEmpty(ex.InnerTypeName)) ? "" : ex.InnerTypeName;
                fullName += (string.IsNullOrEmpty(ex.InnerTypeAssembly)) ? "" : ", " + ex.InnerTypeAssembly;

                // throws an exception if the type can't created
                if (ex.ErrorCode > 0)
                {
                    try
                    {
                        newExeption = ExceptionFactory.CreateException(fullName, ex.ErrorCode, ex.ice_Message_, ex.InnerException);
                    }
                    catch
                    {
                        // throw a new CoreException with the received error code
                        newExeption =
                            ExceptionFactory.CreateCoreException(ex.ErrorCode, ex.ice_Message_, ex.InnerException);
                    }
                }
                else
                {
                    newExeption = ExceptionFactory.CreateException(fullName, ex.ice_Message_, ex.InnerException);
                }
            }
            catch
            {
                // rethrow the given exception as CoreCommunicationException
                newExeption = ExceptionFactory.CreateCoreCommunicationException(1000645, ex.ice_Message_, ex.InnerException);
            }

            throw newExeption;
        }

        /// <summary>
        /// Handles the ice exceptions 
        /// </summary>
        /// <param name="iceEx">The ice exception</param>
        public static void HandleIceException(Ice.Exception iceEx, string methodName)
        {
            throw ExceptionFactory.CreateCoreCommunicationExceptionFromIceException(iceEx, methodName);
        }
    }
}
