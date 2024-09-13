using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsciiStringTest
{
    public class AsciiString
    {
        private readonly char[] _buffer;

        public AsciiString()
        {
            _buffer = new char[0];
        }


        public AsciiString(params char[] chars)
        {
            // Sử dụng từ khóa params để cho phép truyền vào một mảng không xác định số lượng tham số
            _buffer = new char[chars.Length];
            Array.Copy(chars, _buffer, chars.Length);
        }

        public AsciiString(string originalString)
        {
            // Chuyển đổi string thành mảng char
            _buffer = originalString.ToCharArray();
        }

        public int Capacity{
            get{
                return _buffer.Length;
            }
        }

        public int Length{
            get{
                int length= 0;
                foreach(char c in _buffer)
                {
                    if(c !='\0'){
                        length++;
                    }
                }
                return length;
            }
        }

        public override string ToString(){
            return new string (_buffer);
        }

        public static AsciiString operator +(AsciiString a, AsciiString b){
            int newlengt= a.Length+ b.Length;
            char[] newBuffer= new char[newlengt];

            Array.Copy(a._buffer, newBuffer, a.Length);
            Array.Copy(b._buffer,0, newBuffer,a.Length,b.Length);

            return new AsciiString(newBuffer);
        }

        public int FindIndex(char characterToFind){
            for(int i=0;i<_buffer.Length; i++){
                if(_buffer [i]== characterToFind){
                    return i;
                }
            }
            return -1;
        }
        public AsciiString ToUpper(){
            char [] toupperBuffer= new char[_buffer.Length];
            for(int i=0;i<_buffer.Length; i++){
                toupperBuffer[i]=char.ToUpper(_buffer [i]);//Chuyển đổi từng ký tự thành chữ in hoa
            }
            return new AsciiString(toupperBuffer); // Trả về một instance mới của Buffer
        }

        public AsciiString ToLower(){
            char [] tolowerBuffer = new char[_buffer.Length];
            for (int i=0;i<_buffer.Length ; i++){
                tolowerBuffer[i]=char.ToLower(_buffer [i]);// chuyen doi ky tu thanh kieu thuong
            }
            return new AsciiString(tolowerBuffer);
        }

        
    

    }

}