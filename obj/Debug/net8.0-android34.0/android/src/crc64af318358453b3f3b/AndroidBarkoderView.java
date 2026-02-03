package crc64af318358453b3f3b;


public class AndroidBarkoderView
	extends androidx.appcompat.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer,
		com.barkoder.interfaces.BarkoderResultCallback,
		com.barkoder.interfaces.FlashAvailableCallback,
		com.barkoder.interfaces.MaxZoomAvailableCallback
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_scanningFinished:([Lcom/barkoder/Barkoder$Result;[Landroid/graphics/Bitmap;Landroid/graphics/Bitmap;)V:GetScanningFinished_arrayLcom_barkoder_Barkoder_Result_arrayLandroid_graphics_Bitmap_Landroid_graphics_Bitmap_Handler:Com.Barkoder.Interfaces.IBarkoderResultCallbackInvoker, BarkoderBindingMauiAndroid\n" +
			"n_onFlashAvailable:(Z)V:GetOnFlashAvailable_ZHandler:Com.Barkoder.Interfaces.IFlashAvailableCallbackInvoker, BarkoderBindingMauiAndroid\n" +
			"n_onMaxZoomAvailable:(F)V:GetOnMaxZoomAvailable_FHandler:Com.Barkoder.Interfaces.IMaxZoomAvailableCallbackInvoker, BarkoderBindingMauiAndroid\n" +
			"";
		mono.android.Runtime.register ("Plugin.Maui.Barkoder.Controls.AndroidBarkoderView, Plugin.Maui.Barkoder", AndroidBarkoderView.class, __md_methods);
	}


	public AndroidBarkoderView ()
	{
		super ();
		if (getClass () == AndroidBarkoderView.class) {
			mono.android.TypeManager.Activate ("Plugin.Maui.Barkoder.Controls.AndroidBarkoderView, Plugin.Maui.Barkoder", "", this, new java.lang.Object[] {  });
		}
	}


	public AndroidBarkoderView (int p0)
	{
		super (p0);
		if (getClass () == AndroidBarkoderView.class) {
			mono.android.TypeManager.Activate ("Plugin.Maui.Barkoder.Controls.AndroidBarkoderView, Plugin.Maui.Barkoder", "System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0 });
		}
	}

	public AndroidBarkoderView (com.barkoder.BarkoderView p0)
	{
		super ();
		if (getClass () == AndroidBarkoderView.class) {
			mono.android.TypeManager.Activate ("Plugin.Maui.Barkoder.Controls.AndroidBarkoderView, Plugin.Maui.Barkoder", "Com.Barkoder.BarkoderView, BarkoderBindingMauiAndroid", this, new java.lang.Object[] { p0 });
		}
	}


	public void scanningFinished (com.barkoder.Barkoder.Result[] p0, android.graphics.Bitmap[] p1, android.graphics.Bitmap p2)
	{
		n_scanningFinished (p0, p1, p2);
	}

	private native void n_scanningFinished (com.barkoder.Barkoder.Result[] p0, android.graphics.Bitmap[] p1, android.graphics.Bitmap p2);


	public void onFlashAvailable (boolean p0)
	{
		n_onFlashAvailable (p0);
	}

	private native void n_onFlashAvailable (boolean p0);


	public void onMaxZoomAvailable (float p0)
	{
		n_onMaxZoomAvailable (p0);
	}

	private native void n_onMaxZoomAvailable (float p0);

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
