#import "SafeAreaImpl.h"
#include "UnityAppController.h"
#include "UI/UnityView.h"
#define isEdgeProtectOn(n) n > 1
#define invaildEdgeValue(n) n < 1
#define invaildEdge 0
#define EdgeOff 1
#define EdgeOn 2
#define EdgeDefult EdgeOn

#if defined(__cplusplus)
extern "C" {
#endif
    extern void       UnitySendMessage(const char* obj, const char* method, const char* msg);
#if defined(__cplusplus)
}
#endif

extern "C" void GetSafeAreaImpl(float* l, float* r, float* b, float* t, float* w, float* h)
{
	UIView* view = GetAppController().unityView;
	CGSize screenSize = view.bounds.size;
	float scale = view.contentScaleFactor;
	
	UIEdgeInsets insets = UIEdgeInsetsMake(0, 0, 0, 0);
	if ([UIDevice currentDevice].systemVersion.doubleValue >= 11.0 && [view respondsToSelector: @selector(safeAreaInsets)])
		insets = [view safeAreaInsets];
	
	*l = insets.left * scale;
	*r = insets.right * scale;
	*b = insets.bottom * scale;
	*t = insets.top * scale;
	*w = (screenSize.width - insets.left - insets.right) * scale;
	*h = (screenSize.height - insets.top - insets.bottom) * scale;
}

extern "C" void AddChangeOrientationListener()
{
	[[NSNotificationCenter defaultCenter]addObserver:[SafeAreaImplInstnce sharedInstance] selector:@selector(changeRotate:) name:UIDeviceOrientationDidChangeNotification object:nil];
}

extern "C" void RemoveChangeOrientationListener()
{
	[[NSNotificationCenter defaultCenter] removeObserver:[SafeAreaImplInstnce sharedInstance] name:UIDeviceOrientationDidChangeNotification object:nil];
}

extern "C" void SwitchIPhoneXEdgeProtect(bool bSwitch)
{
    //0:defult
    //1:edgeProtectOff
    //2:edgeProtectOn
    [[NSUserDefaults standardUserDefaults] setInteger:(bSwitch ? EdgeOn : EdgeOff) forKey:@"EdgeProtect"];
    [[NSUserDefaults standardUserDefaults] synchronize];
}

@implementation SafeAreaImpl : NSObject
@end

@implementation SafeAreaImplInstnce

static SafeAreaImplInstnce * _sharedService = nil;

+ (SafeAreaImplInstnce*)sharedInstance {
    static dispatch_once_t onceAPService;
    dispatch_once(&onceAPService, ^{
        _sharedService = [[SafeAreaImplInstnce alloc] init];
    });
    return _sharedService;
}

+(bool)getEdgeProtect
{
    NSInteger nEdgeProtect = [[NSUserDefaults standardUserDefaults] integerForKey:@"EdgeProtect"];
    if(invaildEdgeValue(nEdgeProtect))
    {
        nEdgeProtect = EdgeDefult;
        SwitchIPhoneXEdgeProtect(isEdgeProtectOn(nEdgeProtect));
    }
    return isEdgeProtectOn(nEdgeProtect);
}

- (void)changeRotate:(NSNotification*)noti 
{
    if([[UIDevice currentDevice] orientation] == UIInterfaceOrientationLandscapeLeft)
    {
        UnitySendMessage("SafeArea","OnChangeOrientation", "true");
    }
    else if ([[UIDevice currentDevice] orientation] == UIInterfaceOrientationLandscapeRight)
    {
        UnitySendMessage("SafeArea","OnChangeOrientation", "false");
    }
}

@end
