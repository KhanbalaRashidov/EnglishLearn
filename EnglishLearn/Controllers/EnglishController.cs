using EnglishLearn.Entities;
using EnglishLearn.Models;
using EnglishLearn.Repositories.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace EnglishLearn.Controllers
{
    [Route("api/english")]
    [ApiController]
    public class EnglishController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _environment;

        public EnglishController(IUnitOfWork unitOfWork,IHostingEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
        }

        [HttpGet("getAll")]
        public IActionResult Get()
        {
            var result = _unitOfWork.EnglishRepository.FindAll();
            return Ok(result);
        }

        [HttpGet("get-by-id")]
        public IActionResult Get(int id)
        {
            var result = _unitOfWork.EnglishRepository.FindByCondition(x => x.Id == id);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Post([FromForm] EnglishModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var uniquieFileName = await UploadImage(model.File);
            var vocabulary = new Vocabulary()
            {
                WordEng = model.WordEng,
                WordAze = model.WordAze,
                WordSound = model.WordSound,
                ImagePath = uniquieFileName,
            };
            _unitOfWork.EnglishRepository.Create(vocabulary);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Put([FromForm]EnglishModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var vocabulary = _unitOfWork.EnglishRepository.FindByCondition(x => x.Id == model.Id).GetEnumerator().Current;
            if (vocabulary == null)
            {
                return NotFound();
            }
            vocabulary.WordEng = model.WordEng;
            vocabulary.WordAze = model.WordAze;
            vocabulary.ImagePath = await UploadImage(model.File);
            vocabulary.WordSound = model.WordSound;

            _unitOfWork.EnglishRepository.Update(vocabulary);
            _unitOfWork.Save();

            return Ok(vocabulary);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var vocabulary = _unitOfWork.EnglishRepository.FindByCondition(x => x.Id == id).GetEnumerator().Current;
            if (vocabulary == null)
            {
                return NotFound();
            }
            _unitOfWork.EnglishRepository.Delete(vocabulary);
            _unitOfWork.Save();
            return Ok();
        }

        private async Task<string> UploadImage(IFormFile file)
        {
            string uniqueFileName = null;
            if (file != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(_environment.WebRootPath,@"Images", uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                   await file.CopyToAsync(fileStream);
                }

                uniqueFileName = filePath;
            }

            return uniqueFileName;
        }
    }
}