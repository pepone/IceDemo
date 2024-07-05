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
                    enum SurfaceLevelDto 
                    {
                        UndefinedSurfaceLevelDto = 0,
                        TopSurfaceLevelDto = 1,
                        BottomSurfaceLevelDto = 2,
                    };


                    // define collection of enum
                    ["clr:generic:List"]
                    sequence<SurfaceLevelDto> SurfaceLevelDtoSeq;
                };
            };
        };
    };
};
    
 