﻿using NHibernate;
using NHibernate.Linq;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class vehiclesRepository: reposiroryDSRDAO<vehicles>
    {
        public IList<vehicles> loadNeedPositionUpdate(int timeStamp)
        {
            using (ISession session = sessionFacrtoy.openSession())
            {
                try
                {
                    DateTime limit = (DateTime.Now.AddSeconds(timeStamp * -1));
                    return session.Query<vehicles>()
                                  .Where(p => (p.last_update < limit) || (p.last_update == null))
                                  .ToList();
                }
                catch(Exception ex)
                {
                    return null;
                }
            }
        }
        public vehicles loadVehicleByPhone(string value)
        {
            using (ISession session = sessionFacrtoy.openSession())
            {
                try
                {
                    return session.Query<vehicles>()
                                  .Where(p => p.phone_number.Contains(value)).SingleOrDefault();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        public vehicles loadVehicleByImei(string value)
        {
            using (ISession session = sessionFacrtoy.openSession())
            {
                try
                {
                    return session.Query<vehicles>()
                                  .Where(p => p.imei.Contains(value)).SingleOrDefault();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
