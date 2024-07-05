using System;
using System.Collections;
using System.Collections.Generic;
using AWSOA.Core.Contracts.DataTransferObject;
using AWSOA.Core.Contracts.Extensions;

namespace AW.Clarity.PatternViewer.Contracts.DataTransferObject
{
    //[Serializable]
    [System.CodeDom.Compiler.GeneratedCode("AWSOA.Commercial.CodeGeneration", "13.0.0.0")]
    public partial class SheetDto 
    {
        #region Factory methods
        /// <summary>
        /// Factory for a SheetDto object
        /// </summary>
        /// <returns>a new instance of the SheetDto object</returns>
        public static SheetDto CreateInstance()
        {
            var dto = new SheetDto();
            dto.Guid = new GuidDto();
            dto.Text = new System.Collections.Generic.Dictionary<System.String, System.String>();
            dto.Contour = new System.Collections.Generic.List<AW.Clarity.PatternViewer.Contracts.DataTransferObject.LineDto>();
            dto.InnerLines = new System.Collections.Generic.List<AW.Clarity.PatternViewer.Contracts.DataTransferObject.LineDto>();
            dto.Rotated = false;
            dto.ShapeOptCoordinateSystem = new AW.Clarity.PatternViewer.Contracts.DataTransferObject.Rectangle2DDto();

            dto.IsOnHarpRack = false;
            return dto;
        }

        /// <summary>
        /// Factory for a SheetDto object
        /// </summary>
        /// <param name="x">Action on the object for initialization</param>
        /// <returns>a new instance of the SheetDto object</returns>
        public static SheetDto CreateInstance(Action<SheetDto> x)
        {
            var dto = CreateInstance();

            x.Invoke(dto);

            return dto;
        }

        #endregion
        
        #region override ToString()
        public override string ToString()
        {
          //var result = "Sheet: " + string.Join("; ", 
          var result = string.Join(", ",
                            string.Format("Guid='{0}'", this.Guid),
                            string.Format("BreakingSequence='{0}'", this.BreakingSequence),
                            string.Format("CurrentItemsOnRack='{0}'", this.CurrentItemsOnRack.HasValue ? this.CurrentItemsOnRack.Value : 0),
                            string.Format("TotalItemsOnRack='{0}'", this.TotalItemsOnRack.HasValue ? this.TotalItemsOnRack.Value : 0),
                            string.Format("IsBrokenSheet='{0}'", this.IsBrokenSheet),
                            string.Format("IsBreakageProposal='{0}'", this.IsBreakageProposal.HasValue ? this.IsBreakageProposal.Value : false),
                            string.Format("IsSelectedSheet='{0}'", this.IsSelectedSheet),                        
                            string.Format("PaneType='{0}'", this.PaneType),                        
                            string.Format("Text='{0}'", this.Text),                        
                            string.Format("Contour='{0}'", this.Contour),
                            string.Format("InnerLines='{0}'", this.InnerLines),
                            string.Format("TextArea='{0}'", this.TextArea != null ? this.TextArea.ToString() : null),
                            string.Format("Rotated='{0}'", this.Rotated.HasValue ? this.Rotated.Value : false),
                            string.Format("ShapeOptCoordinateSystem='{0}'", this.ShapeOptCoordinateSystem.HasValue ? this.ShapeOptCoordinateSystem.Value.ToString() : "0"),
                            string.Format("IsOnHarpRack='{0}'", this.IsOnHarpRack.HasValue ? this.IsOnHarpRack.Value : false),
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
 
