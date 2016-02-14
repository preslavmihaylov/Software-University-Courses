#include <linux/kernel.h>
#include <linux/module.h>

void stop_func(void) {
	printk(KERN_WARNING "Stop\n");
}
