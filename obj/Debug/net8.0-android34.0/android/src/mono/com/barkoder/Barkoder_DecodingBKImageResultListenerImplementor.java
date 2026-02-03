package mono.com.barkoder;


public class Barkoder_DecodingBKImageResultListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.barkoder.Barkoder.DecodingBKImageResultListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onDecoded:([Lcom/barkoder/Barkoder$Result;Lcom/barkoder/Barkoder$BKImage;)V:GetOnDecoded_arrayLcom_barkoder_Barkoder_Result_Lcom_barkoder_Barkoder_BKImage_Handler:Com.Barkoder.Barkoder/IDecodingBKImageResultListenerInvoker, BarkoderBindingMauiAndroid\n" +
			"";
		mono.android.Runtime.register ("Com.Barkoder.Barkoder+IDecodingBKImageResultListenerImplementor, BarkoderBindingMauiAndroid", Barkoder_DecodingBKImageResultListenerImplementor.class, __md_methods);
	}


	public Barkoder_DecodingBKImageResultListenerImplementor ()
	{
		super ();
		if (getClass () == Barkoder_DecodingBKImageResultListenerImplementor.class) {
			mono.android.TypeManager.Activate ("Com.Barkoder.Barkoder+IDecodingBKImageResultListenerImplementor, BarkoderBindingMauiAndroid", "", this, new java.lang.Object[] {  });
		}
	}


	public void onDecoded (com.barkoder.Barkoder.Result[] p0, com.barkoder.Barkoder.BKImage p1)
	{
		n_onDecoded (p0, p1);
	}

	private native void n_onDecoded (com.barkoder.Barkoder.Result[] p0, com.barkoder.Barkoder.BKImage p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
