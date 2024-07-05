using System;
using System.Collections;
using System.Collections.Generic;
using AWSOA.Core.Contracts.DataTransferObject;
using AWSOA.Core.Contracts.Extensions;

namespace AW.Clarity.PatternViewer.Contracts.DataTransferObject
{
    //[Serializable]
    [System.CodeDom.Compiler.GeneratedCode("AWSOA.Commercial.CodeGeneration", "13.0.0.0")]
    public partial class PatternRectangleDto 
    {
        #region Factory methods
        /// <summary>
        /// Factory for a PatternRectangleDto object
        /// </summary>
        /// <returns>a new instance of the PatternRectangleDto object</returns>
        public static PatternRectangleDto CreateInstance()
        {
            var dto = new PatternRectangleDto();
            dto.Guid = new GuidDto();
            dto.Childs = new System.Collections.Generic.List<AW.Clarity.PatternViewer.Contracts.DataTransferObject.PatternRectangleDto>();
            dto.Sheets = new System.Collections.Generic.List<AW.Clarity.PatternViewer.Contracts.DataTransferObject.SheetDto>();
            dto.GeometryGuid = new GuidDto();
            dto.MarkCutWithArrow = false;
            return dto;
        }

        /// <summary>
        /// Factory for a PatternRectangleDto object
        /// </summary>
        /// <param name="x">Action on the object for initialization</param>
        /// <returns>a new instance of the PatternRectangleDto object</returns>
        public static PatternRectangleDto CreateInstance(Action<PatternRectangleDto> x)
        {
            var dto = CreateInstance();

            x.Invoke(dto);

            return dto;
        }

        #endregion
        
        #region override ToString()
        public override string ToString()
        {
          //var result = "PatternRectangle: " + string.Join("; ", 
          var result = string.Join(", ",
                            string.Format("Guid='{0}'", this.Guid),                        
                            string.Format("Rectangle='{0}'", this.Rectangle != null ? this.Rectangle.ToString() : null ),
                            string.Format("Childs='{0}'", this.Childs),
                            string.Format("Sheets='{0}'", this.Sheets),
                            string.Format("GeometryGuid='{0}'", this.GeometryGuid),
                            string.Format("MarkCutWithArrow='{0}'", this.MarkCutWithArrow),
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
 
