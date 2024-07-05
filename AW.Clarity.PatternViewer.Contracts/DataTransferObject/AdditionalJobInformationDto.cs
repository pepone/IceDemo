using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Clarity.PatternViewer.Contracts.DataTransferObject
{
    [System.CodeDom.Compiler.GeneratedCode("AWSOA.Commercial.CodeGeneration", "13.0.0.0")]
    public partial class AdditionalJobInformationDto
    {
        #region Factory methods
        /// <summary>
        /// Factory for a DefectDto object
        /// </summary>
        /// <returns>a new instance of the DefectDto object</returns>
        public static AdditionalJobInformationDto CreateInstance()
        {
            var dto = new AdditionalJobInformationDto();
            return dto;
        }

        /// <summary>
        /// Factory for a DefectDto object
        /// </summary>
        /// <param name="x">Action on the object for initialization</param>
        /// <returns>a new instance of the DefectDto object</returns>
        public static AdditionalJobInformationDto CreateInstance(Action<AdditionalJobInformationDto> x)
        {
            var dto = CreateInstance();

            x.Invoke(dto);

            return dto;
        }

        #endregion

        #region override ToString()
        public override string ToString()
        {
            var result = string.Join(", ",
                            string.Format(CultureInfo.InvariantCulture, "JobDescription='{0}'", this.JobDescription),
                            string.Format(CultureInfo.InvariantCulture, "GlassType='{0}'", this.GlassType),
                            string.Format(CultureInfo.InvariantCulture, "ArticleNumber='{0}'", this.ArticleNumber),
                            ""
                        );
            return result;
        }
        #endregion

    }
}
