using System;

namespace SQT.FRAMEWORK.DAL
{
	public class DalException : Exception
	{
		public DalException() : base() {}
		public DalException(string message) : base(message) {}
		public DalException(string message, System.Exception innerException) : base(message,innerException) {}
	}
	public class DalUniqueConstraintException : DalException
	{
		public DalUniqueConstraintException() : base() {}
		public DalUniqueConstraintException(string message) : base(message) {}
		public DalUniqueConstraintException(string message, System.Exception innerException) : base(message,innerException) {}
	}
	public class DalLoginException : DalException
	{
		public DalLoginException() : base() {}
		public DalLoginException(string message) : base(message) {}
		public DalLoginException(string message, System.Exception innerException) : base(message,innerException) {}
	}
	public class DalForeignKeyException : DalException
	{
		public DalForeignKeyException() : base() {}
		public DalForeignKeyException(string message) : base(message) {}
		public DalForeignKeyException(string message, System.Exception innerException) : base(message,innerException) {}
	}
	public class DalDeadLockException : DalException
	{
		public DalDeadLockException() : base() {}
		public DalDeadLockException(string message) : base(message) {}
		public DalDeadLockException(string message, System.Exception innerException) : base(message,innerException) {}
	}
}
