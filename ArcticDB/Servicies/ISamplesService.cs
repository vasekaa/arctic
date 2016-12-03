using ArcticDB.Model;
using System.Collections.Generic;

namespace ArcticDB.Servicies
{
    internal interface ISamplesService
    {
        List<SamplePojo> getAllSamples();
        SamplePojo addSample(SamplePojo samplePojo);
        SamplePojo removeSample(int samplePojoId);
        void removeMetaBySample(int samplePojoId);
        SamplePojo getSampleBySampleId(int samplePojoId);
        void updateSample(SamplePojo samplePojo);
        List<MetaObject> getMetaBySampleId(int samplePojoId, int Type);
        List<SamplePojo> getSamplesByKeywords(string[] keywords);
        List<string> getFilelistBySample(int samplePojoId);
        void addMetaBySample(SamplePojo samplePojo);
        List<MetaObject> getAllMetaByType(int type);
    }
}