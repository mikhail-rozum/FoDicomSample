namespace FoDicomSample
{
    using System;

    using Dicom;
    using Dicom.Imaging.Codec;

    class Program
    {
        static void Main(string[] args)
        {
            TranscoderManager.SetImplementation(new Efferent.Native.Codec.NativeTranscoderManager());

            var path = @"1.3.6.1.4.1.41327.1412220253660.4803989431405291768.dcm";

            var dcm = DicomFile.Open(path);
            var convertedFile = dcm.Clone(DicomTransferSyntax.DeflatedExplicitVRLittleEndian);
            var pixelData = convertedFile.Dataset.GetValues<byte>(DicomTag.PixelData);

            Console.ReadKey();
        }
    }
}
