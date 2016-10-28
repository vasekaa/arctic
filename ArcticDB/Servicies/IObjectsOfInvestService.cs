using ArcticDB.Model;
using System.Collections.Generic;

namespace ArcticDB.Servicies
{
    internal interface IObjectsOfInvestService
    {
        List<ObjectOfInvestigationPojo> getAllObjectOfInvestigations();
        ObjectOfInvestigationPojo addObjectOfInvestigation(ObjectOfInvestigationPojo objectOfInvestigation);
        ObjectOfInvestigationPojo removeObjectOfInvestigation(int objectOfInvestigationId);
        void updateObjectOfInvestigation(ObjectOfInvestigationPojo objectOfInvestigation);
        List<Characteristic> getObjectCharactsByObjctId(int objectOfInvestigationId);
    }
}