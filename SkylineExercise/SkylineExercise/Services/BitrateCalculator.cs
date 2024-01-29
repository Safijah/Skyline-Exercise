using SkylineExercise.Models;

namespace SkylineExercise.Services
{
    public class BitrateCalculator
    {
        public static void CalculateBitrates(DeviceData deviceData)
        {
            foreach (var nic in deviceData.NIC)
            {
                // Assuming the polling rate is 2Hz
                double pollingRate = 2.0;

                // Calculate bitrates for Rx and Tx
                double rxBitrate = nic.Rx / pollingRate;
                double txBitrate = nic.Tx / pollingRate;

                // Print the results
                Console.WriteLine($"NIC Description: {nic.Description}");
                Console.WriteLine($"Rx Bitrate: {rxBitrate} bits/s");
                Console.WriteLine($"Tx Bitrate: {txBitrate} bits/s");
                Console.WriteLine();
            }
        }
    }
}
