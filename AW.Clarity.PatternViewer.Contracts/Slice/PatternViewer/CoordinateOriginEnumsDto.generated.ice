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
					enum CoordinateOriginDto 
					{
						UndefinedCoordinateOriginDto = 0,
						BottomLeftCoordinateOriginDto = 1,
						TopLeftCoordinateOriginDto = 2,
						TopRightCoordinateOriginDto = 3,
						BottomRightCoordinateOriginDto = 4,
					};


					// define collection of enum
					["clr:generic:List"]
					sequence<CoordinateOriginDto> CoordinateOriginDtoSeq;
				};
			};
		};
	};
};
