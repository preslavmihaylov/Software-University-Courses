#include <linux/kernel.h>
#include <linux/init.h>
#include <linux/module.h>

static int __init init(void) {
	printk(KERN_ERR "Hello\n");
	return 0;
}

static void __exit cleanup(void) {
	printk(KERN_ERR "Goodbye\n");
}

module_init(init);
module_exit(cleanup);
