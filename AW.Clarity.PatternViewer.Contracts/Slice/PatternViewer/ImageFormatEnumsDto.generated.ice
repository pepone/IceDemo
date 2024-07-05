﻿ 
//----------------------
// <auto-generated>
//     AWSOA.Core.CodeGeneration
// </auto-generated>
//----------------------
#pragma once

module AW{
    module Clarity{
        module PatternViewer{
            module Contracts {
                module DataTransferObject{

                    // Create the enum for the DTO
                    enum ImageFormatDto 
                    {
                        UndefinedImageFormatDto = 0,
                        BmpImageFormatDto = 1,
                        JpgImageFormatDto = 2,
                        PngImageFormatDto = 3,
                        IcoImageFormatDto = 4,
                        SvgImageFormatDto = 5,
                        XamlImageFormatDto = 6,
                    };


                    // define collection of enum
                    ["clr:generic:List"]
                    sequence<ImageFormatDto> ImageFormatDtoSeq;


                };
            };
        };
    };
};
    
 