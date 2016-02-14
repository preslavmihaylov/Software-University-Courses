#include <linux/kernel.h>
#include <linux/init.h>
#include <linux/module.h>

int arr[20];
int count = 0;

module_param_array(arr,int, &count, 0);

static int __init init(void) {
	int i;
	printk(KERN_INFO "Hello\n");
	for (i = 0; i < count; ++i) {
		printk(KERN_WARNING "arr[%d]=%d\n", i, arr[i]);
	}

	return 0;
}

static void __exit cleanup(void) {
	printk(KERN_INFO "Goodbye\n");
}

module_init(init);
module_exit(cleanup);
