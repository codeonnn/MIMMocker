using MIM_Mocker.Implementation;
using MIMMocker.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace MIM_Mocker.WebAPI
{
    public class MockController : ApiController
    {
        private IMockerRepository _mockRepository;
        public MockController()
        {
            _mockRepository = new InMemoryRepository();
        }
        public MockController(IMockerRepository mockRepository)
        {
            _mockRepository = mockRepository;
        }
        public async Task<string> SaveRule(RuleRequest ruleRequest)
        {
            return await _mockRepository.SaveRules(ruleRequest);
        }
    }
}
