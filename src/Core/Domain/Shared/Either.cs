using OneOf;
namespace Smashup.Domain.Shared
{
  public class Either<TL, TR>
  {


    private TL _left { get; set; }
    private TR _right { get; set; }
    private bool isLeft { get; set; }

    public TL left { get { return this._left; } }
    public TR right { get { return this._right; } }


    public Either(TL left)
    {
      this._left = left;
      this.isLeft = true;
    }

    public Either(TR right)
    {
      this._right = right;
      this.isLeft = false;
    }


    public bool IsRight()
    {
      return this._right is TR && !this.isLeft ? true : false;
    }

    public bool IsLeft()
    {
      return this._left is TL && this.isLeft ? true : false;
    }

    public static implicit operator Either<TL, TR>(OneOf<TL> left) => new Either<TL, TR>((TL)left.Value);
    public static implicit operator Either<TL, TR>(TL left) => new Either<TL, TR>(left);
    public static implicit operator Either<TL, TR>(TR right) => new Either<TL, TR>(right);
  }
}