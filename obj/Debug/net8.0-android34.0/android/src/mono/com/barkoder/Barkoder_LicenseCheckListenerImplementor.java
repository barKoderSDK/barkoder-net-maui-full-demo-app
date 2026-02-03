package mono.com.barkoder;


public class Barkoder_LicenseCheckListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.barkoder.Barkoder.LicenseCheckListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLicenseCheck:(Lcom/barkoder/Barkoder$LicenseCheckResult;)V:GetOnLicenseCheck_Lcom_barkoder_Barkoder_LicenseCheckResult_Handler:Com.Barkoder.Barkoder/ILicenseCheckListenerInvoker, BarkoderBindingMauiAndroid\n" +
			"";
		mono.android.Runtime.register ("Com.Barkoder.Barkoder+ILicenseCheckListenerImplementor, BarkoderBindingMauiAndroid", Barkoder_LicenseCheckListenerImplementor.class, __md_methods);
	}


	public Barkoder_LicenseCheckListenerImplementor ()
	{
		super ();
		if (getClass () == Barkoder_LicenseCheckListenerImplementor.class) {
			mono.android.TypeManager.Activate ("Com.Barkoder.Barkoder+ILicenseCheckListenerImplementor, BarkoderBindingMauiAndroid", "", this, new java.lang.Object[] {  });
		}
	}


	public void onLicenseCheck (com.barkoder.Barkoder.LicenseCheckResult p0)
	{
		n_onLicenseCheck (p0);
	}

	private native void n_onLicenseCheck (com.barkoder.Barkoder.LicenseCheckResult p0);

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
