using AutoMapper;
using BSIGeneralAffair.API.BLL.DTOs;
using BSIGeneralAffair.API.BLL.Interfaces;
using BSIGeneralAffair.API.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSIGeneralAffair.API.BLL
{
    public class HomepageBLL : IHomepageBLL
    {
        private readonly IHomepageData _homepageData;

        private readonly IMapper _mapper;

        public HomepageBLL(IHomepageData homepageData, IMapper mapper)
        {
            _homepageData = homepageData;
            _mapper = mapper;
        }

        public async Task<HomepageDTO> Get(string employeeNumber)
        {
            try
            {
                var homepageData = _mapper.Map<HomepageDTO>(await _homepageData.GetHomepage(employeeNumber));
                return homepageData;
            }
            catch (Exception ex)
            {

                throw new ArgumentException($"BLL - {ex.Message}");
            }
        }
    }
}
