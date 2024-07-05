using System;
using System.Collections;
using System.Collections.Generic;
using AWSOA.Core.Contracts.DataTransferObject;
using AWSOA.Core.Contracts.Extensions;

namespace AW.Clarity.PatternViewer.Contracts.DataTransferObject
{
    //[Serializable]
    [System.CodeDom.Compiler.GeneratedCode("AWSOA.Commercial.CodeGeneration", "13.0.0.0")]
    public partial class RectangleDto 
    {
        #region Factory methods
        /// <summary>
        /// Factory for a RectangleDto object
        /// </summary>
        /// <returns>a new instance of the RectangleDto object</returns>
        public static RectangleDto CreateInstance()
        {
            var dto = new RectangleDto();
            return dto;
        }

        /// <summary>
        /// Factory for a RectangleDto object
        /// </summary>
        /// <param name="x">Action on the object for initialization</param>
        /// <returns>a new instance of the RectangleDto object</returns>
        public static RectangleDto CreateInstance(Action<RectangleDto> x)
        {
            var dto = CreateInstance();

            x.Invoke(dto);

            return dto;
        }

        #endregion
        
        #region override ToString()
        public override string ToString()
        {
          //var result = "Rectangle: " + string.Join("; ", 
          var result = string.Join(", ",
                            string.Format("Left='{0}'", this.Left),                        
                            string.Format("Bottom='{0}'", this.Bottom),                        
                            string.Format("Width='{0}'", this.Width),                        
                            string.Format("Height='{0}'", this.Height),                        
                            ""
                        );
          return result;
        }

        #region CompositeIdToString()
        //prevent circular ToString()
        internal string CompositeIdToString()
        {
            string result = "...";
            return result;
        }
        #endregion
        #endregion
    }
}
 
