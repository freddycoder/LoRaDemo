// This projet i a demo on how to read bytes from a LoRa USB dongle
// Using modern c#

using System;

Console.WriteLine("Hello, World!");

try {
    using (var serialPort = new System.IO.Ports.SerialPort("COM6", 115200)) {
        Console.WriteLine("Opening port");
        serialPort.Open();
        Console.WriteLine("Port opened");
        while (true) {
            Console.WriteLine("Bytes to read: " + serialPort.BytesToRead);
            if (serialPort.BytesToRead > 0) {
                byte[] buffer = new byte[serialPort.BytesToRead];
                serialPort.Read(buffer, 0, buffer.Length);
                Console.WriteLine(BitConverter.ToString(buffer));
            }
            await Task.Delay(1000);
        }
    }
} catch (Exception ex) {
    Console.WriteLine(ex.Message);
}
