using System;
using System.IO;
using System.Text;
using System.Text.Json;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;

namespace DotnetCal.Helpers
{
    public class AsymmetricCryptography: IAssmyetricCryptography
    {
        public const string SIGNATURE_ALGORITHM = "SHA512WITHRSA";
        private AsymmetricKeyParameter _privateKey;
        private AsymmetricKeyParameter _publicKey;

        public AsymmetricCryptography() 
        {
            LoadKeys();
        }

        public string SignData<T>(T data)
        {
            var jsonData = JsonSerializer.Serialize(data);
            var dataToSign = Encoding.UTF8.GetBytes(jsonData);

            var signer = SignerUtilities.GetSigner(SIGNATURE_ALGORITHM);

            signer.Init(true, _privateKey);
            signer.BlockUpdate(dataToSign, 0, dataToSign.Length);

            var signature = signer.GenerateSignature();

            return Convert.ToBase64String(signature);
        }

        public bool VerifySignature(string data, string signature)
        {
            var dataToVerify = Encoding.UTF8.GetBytes(data);
            var binarySignature = Convert.FromBase64String(signature);

            var signer = SignerUtilities.GetSigner(SIGNATURE_ALGORITHM);
            signer.Init(false, _publicKey);
            signer.BlockUpdate(dataToVerify, 0, dataToVerify.Length);

            return signer.VerifySignature(binarySignature);
        }

        public string Encrypt<T>(T payload)
        {
            if(_privateKey == null) throw new NotSupportedException("Unable to encrypt, private key hasn't been loaded");

            var jsonPayload = JsonSerializer.Serialize(payload);
            var buffer = Encoding.UTF8.GetBytes(jsonPayload);

            IAsymmetricBlockCipher cipher = new Pkcs1Encoding(new RsaEngine());
            cipher.Init(true, _privateKey);

            var output = cipher.ProcessBlock(buffer, 0, buffer.Length);

            return Convert.ToBase64String(output);            
        }

        public T Decrypt<T>(string payload)
        {
            var buffer = Convert.FromBase64String(payload);
            IAsymmetricBlockCipher cipher = new Pkcs1Encoding(new RsaEngine());
            cipher.Init(false, _publicKey);

            var output = cipher.ProcessBlock(buffer, 0, buffer.Length);

            var jsonPayload = Encoding.UTF8.GetString(output);


            return JsonSerializer.Deserialize<T>(jsonPayload);
        }

        private void LoadKeys() 
        {

            object keyInfo;

            using (var stream = File.OpenText("./tandm-online.key.pem"))
            {
                var PemReader = new PemReader(stream);
                keyInfo = PemReader.ReadObject();
            }

            switch (keyInfo)
            {
                case AsymmetricCipherKeyPair pair:
                    _privateKey = pair.Private;
                    _publicKey = pair.Public;
                    break;

                case Org.BouncyCastle.X509.X509Certificate certificate:                    
                    _publicKey = certificate.GetPublicKey();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(keyInfo), keyInfo, "Unable to interpret Key File");
            }
        }
    }
}