using System;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace LogFileViewer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private static FileRepository FileRepository = new FileRepository();
        private readonly ILogger<FileController> _logger;
        
        public FileController(ILogger<FileController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("storeFile")]
        public String Store([FromBody] FileContent file)
        {
            FileRepository.AddFile(file);
            return file.FileId;
        }

        [HttpGet("byFileId")]
        public IFileContent Get(String fileId)
        {
            if (String.IsNullOrWhiteSpace(fileId) == false)
            {
                if (FileRepository.Files.ContainsKey(fileId))
                {
                    return FileRepository.Files[fileId];
                }

            }
            return null;
        }

        [HttpGet]
        public IEnumerable<IFileContent> Get()
        {
            if (FileRepository.Files.Count == 0)
            {
                return new List<IFileContent>();
            }
            return FileRepository.Files.Values.ToList();
        }

        [HttpGet("bySearchTerm")]
        public IEnumerable<IFileLineMatchInfo> Find(String searchTerm)
        {
            List<IFileLineMatchInfo> queryResults = new List<IFileLineMatchInfo>();

            if (String.IsNullOrWhiteSpace(searchTerm) == false)
            {
                foreach (KeyValuePair<String, IFileContent> file in FileRepository.Files)
                {
                    IList<IFileLineMatchInfo> matches = file.Value.Find(searchTerm);
                    if (matches?.Count > 0)
                    {
                        queryResults.AddRange(matches);
                    }

                }

            }
            return queryResults;
        }
    }
}
