using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Clarity.PatternViewer.Contracts.DataTransferObject
{
    public partial class AdditionalSheetInformationDto
    {
        #region Factory methods
        /// <summary>
        /// Factory for a DefectDto object
        /// </summary>
        /// <returns>a new instance of the DefectDto object</returns>
        public static AdditionalSheetInformationDto CreateInstance()
        {
            var dto = new AdditionalSheetInformationDto();
            return dto;
        }

        /// <summary>
        /// Factory for a DefectDto object
        /// </summary>
        /// <param name="x">Action on the object for initialization</param>
        /// <returns>a new instance of the DefectDto object</returns>
        public static AdditionalSheetInformationDto CreateInstance(Action<AdditionalSheetInformationDto> x)
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
                            string.Format(CultureInfo.InvariantCulture, "InputGuid='{0}'", this.InputGuid),
                            string.Format(CultureInfo.InvariantCulture, "Labelnumber='{0}'", this.LabelNumber),
                            string.Format(CultureInfo.InvariantCulture, "IsGroupLabel='{0}'", this.IsGroupLabel),
                            string.Format(CultureInfo.InvariantCulture, "CustomerName='{0}'", this.CustomerName),
                            string.Format(CultureInfo.InvariantCulture, "Notes='{0}'", this.Notes),
                            string.Format(CultureInfo.InvariantCulture, "Coating='{0}'", this.Coating),
                            ""
                        );
            return result;
        }

        #endregion

    }
}
