using System;
using System.Collections;
using System.Collections.Generic;
using AWSOA.Core.Contracts.DataTransferObject;
using AWSOA.Core.Contracts.Extensions;

namespace AW.Clarity.PatternViewer.Contracts.DataTransferObject
{
    //[Serializable]
    [System.CodeDom.Compiler.GeneratedCode("AWSOA.Commercial.CodeGeneration", "13.0.0.0")]
    public partial class PatternDto 
    {
        #region Factory methods
        /// <summary>
        /// Factory for a PatternDto object
        /// </summary>
        /// <returns>a new instance of the PatternDto object</returns>
        public static PatternDto CreateInstance()
        {
            var dto = new PatternDto();
            dto.Guid = new GuidDto();
            dto.Defects = new System.Collections.Generic.List<AW.Clarity.PatternViewer.Contracts.DataTransferObject.DefectDto>();
            dto.Description = new Ice.Optional<PatternDescriptionDto>();
            return dto;
        }

        /// <summary>
        /// Factory for a PatternDto object
        /// </summary>
        /// <param name="x">Action on the object for initialization</param>
        /// <returns>a new instance of the PatternDto object</returns>
        public static PatternDto CreateInstance(Action<PatternDto> x)
        {
            var dto = CreateInstance();

            x.Invoke(dto);

            return dto;
        }

        #endregion

        #region override ToString()
        public override string ToString()
        {
            //var result = "Pattern: " + string.Join("; ", 
            var result = string.Join(", ",
                            string.Format("Guid='{0}'", this.Guid),
                            string.Format("Rectangle='{0}'", this.Rectangle != null ? this.Rectangle.CompositeIdToString() : null),
                            string.Format("RootRectangle='{0}'", this.RootRectangle != null ? this.RootRectangle.CompositeIdToString() : null),
                            string.Format("Defects='{0}'", this.Defects),
                            string.Format("HeaderText='{0}'", this.HeaderText),
                            string.Format("Origin='{0}'", this.Origin),
                            string.Format("ZoomLevel='{0}'", this.ZoomLevel),
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
 
