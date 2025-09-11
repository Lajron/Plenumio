using Microsoft.AspNetCore.Http;
using Plenumio.Application.DTOs;
using Plenumio.Application.Interfaces;
using Plenumio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plenumio.Application.Interfaces {
    public interface IImageConverter<TFile> {

        IEnumerable<ImageFileDto> ToImageFileDtos(IEnumerable<TFile> files);
    }
}
