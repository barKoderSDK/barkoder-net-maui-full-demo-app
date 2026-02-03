package mono.com.barkoder;


public class Barkoder_DecodingImageResultListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.barkoder.Barkoder.DecodingImageResultListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onDecoded:([Lcom/barkoder/Barkoder$Result;Landroid/media/Image;)V:GetOnDecoded_arrayLcom_barkoder_Barkoder_Result_Landroid_media_Image_Handler:Com.Barkoder.Barkoder/IDecodingImageResultListenerInvoker, BarkoderBindingMauiAndroid\n" +
			"";
		mono.android.Runtime.register ("Com.Barkoder.Barkoder+IDecodingImageResultListenerImplementor, BarkoderBindingMauiAndroid", Barkoder_DecodingImageResultListenerImplementor.class, __md_methods);
	}


	public Barkoder_DecodingImageResultListenerImplementor ()
	{
		super ();
		if (getClass () == Barkoder_DecodingImageResultListenerImplementor.class) {
			mono.android.TypeManager.Activate ("Com.Barkoder.Barkoder+IDecodingImageResultListenerImplementor, BarkoderBindingMauiAndroid", "", this, new java.lang.Object[] {  });
		}
	}


	public void onDecoded (com.barkoder.Barkoder.Result[] p0, android.media.Image p1)
	{
		n_onDecoded (p0, p1);
	}

	private native void n_onDecoded (com.barkoder.Barkoder.Result[] p0, android.media.Image p1);

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
