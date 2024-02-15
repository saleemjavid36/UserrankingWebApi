using Microsoft.AspNetCore.Mvc;
using RankingAppWebapi.Interfaces;
using RankingAppWebapi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RankingAppWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRankingController : ControllerBase
    {
        private readonly KcOasContext _KcOasContext;
        private readonly IUserRanking _iUserRanking;
        public UserRankingController(KcOasContext KcOasContext, IUserRanking iUserRanking)
        {
            this._KcOasContext = KcOasContext;
            _iUserRanking = iUserRanking;
        }
        // GET: api/<UserRankingController>
        [HttpGet]
        public List<SampleUserRanking> Get()
        {
            return _iUserRanking.GetAllUserRankings();
        }

        // PUT api/<UserRankingController>/5
        [HttpPut("{id}")]
        public SampleUserRanking Put(int id, [FromBody] SampleUserRanking value)
        {
            //if(id != value.Id)
            //{
            //    throw new Exception("Please enter the valid details");
            //}
            var results = _iUserRanking.UpdateRanking(value, id);
            return results;
        }

    }
}
