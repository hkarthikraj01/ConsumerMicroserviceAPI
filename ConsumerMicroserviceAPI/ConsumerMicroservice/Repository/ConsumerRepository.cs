using ConsumerMicroservice.Data;
using ConsumerMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice.Repository
{
    public class ConsumerRepository : IConsumerRepository
    {
        private readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ConsumerRepository));

        private readonly ApplicationDbContext _db = null;
        public ConsumerRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateBusinessProperty(BusinessProperty businessProperty)
        {
            Property property = new Property()
            {
                PropertyId = businessProperty.PropertyId,
                BuildingSqft = businessProperty.BuildingSqft,
                BuildingType = businessProperty.BuildingType,
                BuildingStoreys = businessProperty.BuildingStoreys,
                BuildingAge = businessProperty.BuildingAge,
                CostOfTheAsset = businessProperty.CostOfTheAsset,
                SalvageValue = businessProperty.SalvageValue,
                UsefulLifeOfTheAsset = businessProperty.UsefulLifeOfTheAsset,
            };

            //PropertyData.PropertyList.Add(property);
            _db.properties.Add(property);
            _db.SaveChanges();
            return true;
        }

        public bool CreateConsumerBusiness(ConsumerBusiness consumerBusiness)
        {
            Consumer consumer = new Consumer()
            {
                ConsumerId = consumerBusiness.ConsumerId,
                ConsumerName = consumerBusiness.ConsumerName,
                Email = consumerBusiness.Email,
                Pan = consumerBusiness.Pan,
                BusinessOverview = consumerBusiness.BusinessOverview,
                ValidityofConsumer = consumerBusiness.ValidityofConsumer,
                AgentId = consumerBusiness.AgentId,
                AgentName = consumerBusiness.AgentName,
            };

            Business business = new Business()
            {
                BusinessId = consumerBusiness.BusinessId,
                BusinessType = consumerBusiness.BusinessType,
                AnnualTurnOver = consumerBusiness.AnnualTurnOver,
                TotalEmployees = consumerBusiness.TotalEmployees,
                CapitalInvested = consumerBusiness.CapitalInvested
            };

            //ConsumerData.ConsumerList.Add(consumer);
            //BusinessData.BusinessList.Add(business);
            _db.consumers.Add(consumer);
            _db.businesses.Add(business);
            _db.SaveChanges();
            return true;

        }

        public Consumer GetConsumerById(string id)
        {
            Consumer consumer =  _db.consumers.Where(t => t.ConsumerId == id).FirstOrDefault();
           //Consumer consumer = ConsumerData.ConsumerList.FirstOrDefault(c => c.ConsumerId.Equals(id));
           return consumer;
        }

        public Business GetBusinessById(string id)
        {
            //Business business = BusinessData.BusinessList.FirstOrDefault(b => b.BusinessId.Equals(id));
            Business business = _db.businesses .Where(t => t.BusinessId == id).FirstOrDefault();
            return business;
        }

        public Property GetPropertyById(string id)
        {
          // Property property = PropertyData.PropertyList.FirstOrDefault(p => p.PropertyId.Equals(id));
          Property property = _db.properties.Where(t => t.PropertyId == id).FirstOrDefault();
          return property;
        }

        public bool UpdateBusinessProperty(BusinessProperty businessProperty)
        {
            Property updateProperty = new Property()
            {
                PropertyId = businessProperty.PropertyId,
                BuildingSqft = businessProperty.BuildingSqft,
                BuildingType = businessProperty.BuildingType,
                BuildingStoreys = businessProperty.BuildingStoreys,
                BuildingAge = businessProperty.BuildingAge,
                CostOfTheAsset = businessProperty.CostOfTheAsset,
                SalvageValue = businessProperty.SalvageValue,
                UsefulLifeOfTheAsset = businessProperty.UsefulLifeOfTheAsset,
            };

            Property deleteProperty = GetPropertyById(businessProperty.PropertyId);

            //PropertyData.PropertyList.Remove(deleteProperty);
            //PropertyData.PropertyList.Add(updateProperty);
            _db.properties.Remove(deleteProperty);
            _db.properties.Add(updateProperty);
            _db.SaveChanges();
            return true;

        }

        public bool UpdateConsumerBusiness(ConsumerBusiness consumerBusiness)
        {

            Consumer updateConsumer = new Consumer()
            {
                ConsumerId = consumerBusiness.ConsumerId,
                ConsumerName = consumerBusiness.ConsumerName,
                Email = consumerBusiness.Email,
                Pan = consumerBusiness.Pan,
                BusinessOverview = consumerBusiness.BusinessOverview,
                ValidityofConsumer = consumerBusiness.ValidityofConsumer,
                AgentId = consumerBusiness.AgentId,
                AgentName = consumerBusiness.AgentName,
            };

            Business updatebusiness = new Business()
            {
                BusinessId = consumerBusiness.BusinessId,
                BusinessType = consumerBusiness.BusinessType,
                AnnualTurnOver = consumerBusiness.AnnualTurnOver,
                TotalEmployees = consumerBusiness.TotalEmployees,
                CapitalInvested = consumerBusiness.CapitalInvested
            };

           Consumer deleteConsumer = GetConsumerById(consumerBusiness.ConsumerId);
           Business deleteBusiness = GetBusinessById(consumerBusiness.BusinessId);

            //ConsumerData.ConsumerList.Remove(deleteConsumer);
            //BusinessData.BusinessList.Remove(deleteBusiness);
            //ConsumerData.ConsumerList.Add(updateConsumer);
            //BusinessData.BusinessList.Add(updatebusiness);
            _db.Remove(deleteConsumer);
            _db.Remove(deleteBusiness);
            _db.Add(updateConsumer);
            _db.Add(updatebusiness);
            _db.SaveChanges();
            return true;
        }

        public ConsumerBusinessDetails ViewConsumerBusiness(string ConsumerId, string BusinessId)
        {
            if (ConsumerId == null || BusinessId == null)
            {
                
                throw new System.ArgumentException("No such customerid is stored");
            }
            Consumer viewConsumer = GetConsumerById(ConsumerId);
            Business viewBusiness = GetBusinessById(BusinessId); 
             ConsumerBusinessDetails consumerBusiness = new ConsumerBusinessDetails()
            {
                ConsumerId = viewConsumer.ConsumerId,
                ConsumerName = viewConsumer.ConsumerName,
                Email = viewConsumer.Email,
                Pan = viewConsumer.Pan,
                AgentId = viewConsumer.AgentId,
                AgentName = viewConsumer.AgentName,
                BusinessId = viewBusiness.BusinessId,
                BusinessOverview = viewConsumer.BusinessOverview,
                ValidityofConsumer = viewConsumer.ValidityofConsumer,
                BusinessType = viewBusiness.BusinessType,
                AnnualTurnOver = viewBusiness.AnnualTurnOver,
                TotalEmployees = viewBusiness.TotalEmployees,
                CapitalInvested = viewBusiness.CapitalInvested,
            };
            try
            {
                consumerBusiness.BusinessValue = viewBusiness.AnnualTurnOver / viewBusiness.CapitalInvested;
            }
            catch (Exception e)
            {
               
                Console.WriteLine(e.Message);
            }
           
            return consumerBusiness;
        }

        public BusinessPropertyDetails ViewConsumerProperty(string ConsumerId, string PropertyId)
        {
            if (ConsumerId == null || PropertyId == null)
            {
                
                throw new System.ArgumentException("No such customerid is stored");
            }
            Property viewProperty = GetPropertyById(PropertyId);

            BusinessPropertyDetails businessProperty = new BusinessPropertyDetails()
            {
                ConsumerId = ConsumerId,
                PropertyId = viewProperty.PropertyId,
                BuildingSqft = viewProperty.BuildingSqft,
                BuildingType = viewProperty.BuildingType,
                BuildingStoreys = viewProperty.BuildingStoreys,
                BuildingAge = viewProperty.BuildingAge,
                CostOfTheAsset = viewProperty.CostOfTheAsset,
                SalvageValue = viewProperty.SalvageValue,
                UsefulLifeOfTheAsset = viewProperty.UsefulLifeOfTheAsset,
                
            };
            try
            {
                businessProperty.PropertyValue = (viewProperty.CostOfTheAsset - viewProperty.SalvageValue) / viewProperty.UsefulLifeOfTheAsset;
            }
            catch (Exception e)
            {
               
                Console.WriteLine(e.Message);
            }

            return businessProperty;
        }

    }
}
