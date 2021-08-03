using ConsumerMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice
{
    public class ConsumerData
    {
        public static List<Consumer> ConsumerList = new List<Consumer>()

        {
           new Consumer()
            {
                ConsumerId = "C01",
                ConsumerName = "Karthi",
                Email = "Karthi@gmail.com",
                Pan = "ABCD1234E",
                BusinessOverview = "Sole Proprietorships",
                ValidityofConsumer = 2 ,
                AgentId = 1,
                AgentName = "Raj"
            },
            new Consumer()
            {
                ConsumerId = "C02",
                ConsumerName = "Prajwal",
                Email = "Prajwal@gmail.com",
                Pan = "ABCD1234D",
                BusinessOverview = "Corporations" ,
                ValidityofConsumer = 2 ,
                AgentId = 2,
                AgentName = "Vijay"
            },
            new Consumer()
            {
                ConsumerId = "C03",
                ConsumerName = "Vishal",
                Email = "Vishal@gmail.com",
                Pan = "ABCD1234X",
                BusinessOverview = "entrepreneurship",
                ValidityofConsumer = 3 ,
                AgentId = 3,
                AgentName = "Ram"
            },
            new Consumer()
            {
                ConsumerId = "C04",
                ConsumerName = "Hari",
                Email = "Hari@gmail.com",
                Pan = "ABCD1234A",
                BusinessOverview = "Startup" ,
                ValidityofConsumer = 1 ,
                AgentId = 4,
                AgentName = "Rahul"
            },
            new Consumer()
            {
                ConsumerId = "C05",
                ConsumerName = "Sai",
                Email = "sai@gmail.com",
                Pan = "ABCD1234Q",
                BusinessOverview = "MNC",
                ValidityofConsumer = 3 ,
                AgentId = 5,
                AgentName = "Sri"
            }
        };
    }
}
