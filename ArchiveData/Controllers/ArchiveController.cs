using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using ArchiveData.Services;
using ArchiveData.Models;

namespace ArchiveData.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArchiveController : ControllerBase
    {
        private readonly ArchiveService ArchiveService;

        public ArchiveController(ArchiveService archive)
        {
            ArchiveService = archive;
        }

        [HttpGet("getalluavs")]
        public async Task<ActionResult<List<string>>> GetAllUavs()
        {
            try
            {
                List<string> uavsNames = await ArchiveService.GetAllUavs();

                if (uavsNames == null || uavsNames.Count == 0)
                {
                    return NotFound("No uavs found.");
                }

                return Ok(uavsNames);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "server error: " + ex.Message);
            }
        }



        [HttpPost("getArchiveData")]
        public async Task<ActionResult<List<ArchiveDataDto>>> ArchiveData([FromBody] ArchiveRequestDto archiveDto)
        {
            try
            {

                List<ArchiveDataDto> archivedUAVsDataList = await ArchiveService.GetArchiveData(archiveDto);

                if (archivedUAVsDataList == null || archivedUAVsDataList.Count == 0)
                {
                    return NotFound("No uavs found.");
                }
                return Ok(archivedUAVsDataList);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "server error: " + ex.Message);
            }

        }

        [HttpPost("getMultiArchiveData")]
        public async Task<ActionResult<List<MultiArchiveDataDto>>> MultiArchiveData([FromBody] ArchiveMultiRequestDto archiveDto)
        {
            try
            {

                List<MultiArchiveDataDto> archivedUAVsDataList = await ArchiveService.GetMultiArchiveData(archiveDto);

                if (archivedUAVsDataList == null || archivedUAVsDataList.Count == 0)
                {
                    return NotFound("No uavs found.");
                }
                return Ok(archivedUAVsDataList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "server error: " + ex.Message);
            }

        }
    }
}
