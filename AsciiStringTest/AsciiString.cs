using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsciiStringTest
{
    public class AsciiString
    {
        
        private readonly char[] _buffer;
        //readonly để ngăn cản việc gán mảng mới vào sau khi instance của AsciiString đã được khởi tạo.
        

        public AsciiString(){
            this._buffer = new char[0];
            //tạo mảng buff với giá trị trong mảng bằng 0
        }

        public AsciiString(params char[] chars){
            _buffer = new char[chars.Length+1];
            // khởi tạo 1 mảng buffer mới có kí tự và độ dài bằng mảng _chars+ 1 đây là giá trị dành cho '\0'
            Array.Copy(chars,_buffer,chars.Length);
            // ở đây sửa dụng array.coppy để sao chép các mảng chars vào trong buffer
            _buffer[chars.Length] = '\0';
        }

        public AsciiString(string originalString){
            _buffer = originalString.ToCharArray();
            //chuyen mang string thanh mang char
        }

        public int Capacity{
            get{
                return _buffer.Length;
            }
        }

        public int Length
        {
            get
            {
                int length = 0;
                foreach (char c in _buffer)
                {
                    if (c != '\0')
                    {
                        length++;
                    }
                }
                return length;
            }
        }

        public override string ToString(){
            return new string (_buffer);
            //day la ep kieu ve string
        }

        public static AsciiString Operate(AsciiString a, AsciiString b){
            // new length= a.Length+ b.Length;
            // char[] newBuffer= new char[length + 1];
            int lengthA = a.Length;
            int lengthB = b.Length;

            char[] newBuffer= new char[lengthA+ lengthB];

            Array.Copy(a._buffer, newBuffer, lengthA);
            //dòng này là lấy các phần tử trong mảng a, và gán vào trong newBuffer
            Array.Copy(b._buffer, 0, newBuffer,lengthA, lengthB);
            //dòng này là lấy các phần tử trong mảng b, và gán vào trong newBuffer
            // 0 đại diện ở vị trí 0, a._buffer là sau khi kết thúc mảng a thì mảng b sẽ ghi vào sau mảng a

            return new AsciiString (newBuffer);
        }

        public int FindIndex(char characterToFind){
            for(int i = 0; i< _buffer.Length; i++){
                if(_buffer [i]== characterToFind){
                    return i;
                }
                //_buffer [i] i đại diện cho vị trí  nếu đungs sẽ trả về vị trí của kí tự đó 
                // ngược lại sai sẽ trả về -1;
            }
            return -1;

        }

        public AsciiString ToUpper1(){
            char [] toUper= new char[_buffer.Length];
            for(int i = 0; i < _buffer.Length; i++){
                toUper[i]= char.ToUpper( _buffer [i] );
                // sử dụng toUpper() của lớp char để chuyển ký tự tại chỉ số i của _buffer thành chữ in hoa, 
                //và gán giá trị này cho vị trí tương ứng trong toupperBuffer.
            }
            return new AsciiString(toUper); // Trả về một instance mới của Buffer
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