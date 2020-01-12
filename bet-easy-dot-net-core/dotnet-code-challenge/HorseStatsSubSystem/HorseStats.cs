using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_code_challenge
{
    public class HorseStats
    {
        private readonly Logger logger;
        private readonly IProvider provider;

        public HorseStats(Logger logger, IProvider provider)
        {
            //Dependecy Injection
            this.logger = logger;
            this.provider = provider;
        }

        /// <summary>
        /// Provides List of Horses with their prices in ascending order.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>List<Horse> but returns NULL value in case no data is available of any exception has occured</returns>
        public List<Horse> GetHorsesStats(string filePath)
        {
            Task<List<Horse>>[] racingTask = null;
            if (Directory.Exists(filePath))
            {
                try
                {
                    string[] dataFiles = Directory.GetFiles(filePath);
                    if (dataFiles.Length > 0)
                    {
                        racingTask = new Task<List<Horse>>[dataFiles.Length];

                        for (int i = 0; i < dataFiles.Length; i++)
                        {
                            int index = i;
                            racingTask[i] = Execute(dataFiles[i]);
                        }
                        Task.WhenAll(racingTask).Wait();
                        return racingTask.SelectMany(t => t.Result).OrderBy(o => o.Price).ToList();
                    }
                }
                catch (DirectoryNotFoundException ex)
                {
                    logger.Error(ex);
                }
                catch (UnauthorizedAccessException ex)
                {
                    logger.Error(ex);
                }
                catch (AggregateException ex)
                {
                    logger.Error(ex);
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }
            else
            {
                logger.Error("Directory is not found");
                throw new DirectoryNotFoundException("Provide valid directory path.");
            }
            return null;
        }

        private async Task<List<Horse>> Execute(string filePath)
        {
            List<Horse> horseList = new List<Horse>();
           
            await Task.Run(() =>
            {
                try
                {
                    horseList = provider.Provide(filePath).ToList();
                }
                catch (ArgumentNullException ex)
                {
                    logger.Error(ex);
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            });
            return horseList;
        }
    }
}
