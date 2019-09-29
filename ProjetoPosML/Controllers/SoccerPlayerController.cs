using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using ProjetoPosML.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetoPosML.Controllers
{
    [Route("api/[controller]")]
    public class SoccerPlayerController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET soccerplayer/65
        [HttpGet("{hability}")]
        public Prediction Get(int hability)
        {
            MLContext mlContext = new MLContext();

            IDataView trainingData = mlContext.Data.LoadFromEnumerable(SoccerPlayer.getPlayers());

            var pipeline = mlContext.Transforms.Concatenate("Features", new[] { "Hability" })
                .Append(mlContext.Regression.Trainers
                    .Sdca(labelColumnName: "Price", maximumNumberOfIterations: 100));

            var model = pipeline.Fit(trainingData);

            var player = new SoccerPlayer() { Hability = hability };
            var price = mlContext.Model
                .CreatePredictionEngine<SoccerPlayer, Prediction>(model)
                .Predict(player);

            return price;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
