using EmployeeLearning.model.jobrole;
using EmployeeLearning.model.video;
using EmployeeLearning.testdata.videostore;


namespace EmployeeLearning.testdata.jobrolestore
{
    public sealed class JobRoleTestDataProvider
    {
        public List<JobRole> JobRoles = new();
        private JobRoleTestDataProvider()
        {
            List<Video> videosOfJobRole1 = new();
            videosOfJobRole1.Add(VideoTestDataProvider.Instance.Videos[0]);
            videosOfJobRole1.Add(VideoTestDataProvider.Instance.Videos[1]);
            JobRoles.Add(new JobRole("JobRole A", videosOfJobRole1));

            List<Video> videosOfJobRole2 = new();
            videosOfJobRole2.Add(VideoTestDataProvider.Instance.Videos[2]);
            videosOfJobRole2.Add(VideoTestDataProvider.Instance.Videos[3]);
            JobRoles.Add(new JobRole("JobRole B", videosOfJobRole2));

            List<Video> videosOfJobRole3 = new List<Video>();
            videosOfJobRole3.Add(VideoTestDataProvider.Instance.Videos[4]);
            videosOfJobRole3.Add(VideoTestDataProvider.Instance.Videos[5]);
            JobRoles.Add(new JobRole("JobRole C", videosOfJobRole3));

            List<Video> videosOfJobRole4 = new List<Video>();
            videosOfJobRole4.Add(VideoTestDataProvider.Instance.Videos[6]);
            videosOfJobRole4.Add(VideoTestDataProvider.Instance.Videos[7]);
            JobRoles.Add(new JobRole("JobRole E", videosOfJobRole4));

            List<Video> videosOfJobRole5 = new List<Video>();
            videosOfJobRole5.Add(VideoTestDataProvider.Instance.Videos[8]);
            videosOfJobRole5.Add(VideoTestDataProvider.Instance.Videos[9]);
            JobRoles.Add(new JobRole("JobRole E", videosOfJobRole5));

            JobRoles.Add(new JobRole("JobRole H", videosOfJobRole2));
            JobRoles.Add(new JobRole("JobRole G", videosOfJobRole3));
            JobRoles.Add(new JobRole("JobRole H", videosOfJobRole4));
            JobRoles.Add(new JobRole("JobRole I", videosOfJobRole5));
            JobRoles.Add(new JobRole("JobRole J", videosOfJobRole1));
        }
        private static JobRoleTestDataProvider? jobRoleStorage = null;
        public static JobRoleTestDataProvider Instance
        {
            get
            {
                jobRoleStorage ??= new JobRoleTestDataProvider();
                return jobRoleStorage;
            }
        }
    }
}
